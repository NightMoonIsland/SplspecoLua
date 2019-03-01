using System;
using System.Collections.Generic;
using System.Text;
using Api;

namespace Vm
{
    public class InstructionsImplement
    {
        public const int LFIELDS_PER_FLUSH = 50;

        public static void Move(int i, ILuaVM vm)
        {
            int a = Instruction.GetA(i) + 1;
            int b = Instruction.GetB(i) + 1;
            vm.Copy(b, a);
        }

        public static void LoadK(int i, ILuaVM vm)
        {
            int a = Instruction.GetA(i) + 1;
            int bx = Instruction.GetBx(i);
            vm.GetConst(bx);
            vm.Replace(a);
        }

        public static void LoadKx(int i, ILuaVM vm)
        {
            int a = Instruction.GetA(i) + 1;
            int ax = Instruction.GetAx(vm.Fetch());
            vm.GetConst(ax);
            vm.Replace(a);
        }

        public static void Jmp(int i, ILuaVM vm)
        {
            int a = Instruction.GetA(i);
            int sBx = Instruction.GetSBx(i);
            vm.AddPC(sBx);
            if(a != 0)
            {
                throw new Exception("Jmp: a != 0");
            }
        }

        public static void LoadNil(int i, ILuaVM vm)
        {
            int a = Instruction.GetA(i) + 1;
            int b = Instruction.GetB(i);
            vm.PushNil();
            for(int j = a; j <= a + b; j++)
            {
                vm.Copy(-1, j);
            }
            vm.Pop(1);
        }

        //R(A) := {} (size = B,C)
        public static void NewTable(int i, ILuaVM vm)
        {
            int a = Instruction.GetA(i) + 1;
            int b = Instruction.GetB(i) + 1;
            int c = Instruction.GetC(i);
            vm.GetRK(c);
        }

        //R(A) := R(B)[RK(C)]
        public static void GetTable(int i, ILuaVM vm)
        {
            int a = Instruction.GetA(i) + 1;
            int b = Instruction.GetB(i) + 1;
            int c = Instruction.GetC(i);
            vm.GetRK(c);
            vm.GetTable(b);
            vm.Replace(a);
        }

        //R(A)[RK(B)] := RK(C)
        public static void SetTable(int i, ILuaVM vm)
        {
            int a = Instruction.GetA(i) + 1;
            int b = Instruction.GetB(i) + 1;
            int c = Instruction.GetC(i);
            vm.GetRK(b);
            vm.GetRK(c);
            vm.SetTable(a);
        }

        //R(A)[(C - 1)*FPF+i] := R(A + i)
        public static void SetList(int i, ILuaVM vm)
        {
            int a = Instruction.GetA(i) + 1;
            int b = Instruction.GetB(i);
            int c = Instruction.GetC(i);
            c = c > 0 ? c - 1 : Instruction.GetAx(vm.Fetch());

            vm.CheckStack(1);
            int idx = c * LFIELDS_PER_FLUSH;
            for(int j = 1; j <= b; j++)
            {
                idx++;
                vm.PushValue(a + j);
                vm.SetI(a, idx);
            }
        }

        #region LFunction
        //(iBx) R(A) := closure(KPROTO[Bx])
        public static void Closure(int i, ILuaVM vm)
        {
            int a = Instruction.GetA(i);
            int bx = Instruction.GetBx(i);
            vm.LoadProto(bx);
            vm.Replace(a);
        }

        //(iABC) R(A),R(A+1)...,R(A+C-2) := R(A)(R(A+1),R(A+2),....,R(A+B-1))
        public static void Call(int i, ILuaVM vm)
        {
            int a = Instruction.GetA(i) + 1;
            int b = Instruction.GetB(i);
            int c = Instruction.GetC(i);
            int nArgs = pushFuncAndArgs(a, b, vm);
            vm.Call(nArgs, c - 1);
            popResult(a, c, vm);
        }

        //(iABC) return R(A), R(A + 1), ......, + R(A + B - 2)
        public static void Return(int i, ILuaVM vm)
        {
            int a = Instruction.GetA(i) + 1;
            int b = Instruction.GetB(i);
            if(b == 1)
            {

            }
            else if(b > 1)
            {
                vm.CheckStack(b - 1);
                for(int j = a; j <= a + b - 2; j++)
                {
                    vm.PushValue(j);
                }
            }
            else
            {
                fixStack(a, vm);
            }
        }

        //(iABC) R(A),R(A+1),....R(A+B-2) = vararg
        public static void Vararg(int i, ILuaVM vm)
        {
            int a = Instruction.GetA(i) + 1;
            int b = Instruction.GetB(i);
            if(b != 1)
            {
                vm.LoadVararg(b - 1);
                popResult(a, b, vm);
            }
        }

        //R(A + 1) ：= R(B); R(A) := R(B)[RK(C)]
        public static void Self(int i, ILuaVM vm)
        {
            int a = Instruction.GetA(i) + 1;
            int b = Instruction.GetB(i) + 1;
            int c = Instruction.GetC(i);
            vm.Copy(b, a + 1);
            vm.GetRK(c);
            vm.GetTable(b);
            vm.Replace(a);
        }

        static int pushFuncAndArgs(int a, int b, ILuaVM vm)
        {
            if (b >= 1)
            {
                vm.CheckStack(a);
                for (int i = a; i <= a + b; i++)
                {
                    vm.PushValue(i);
                }
                return b - 1;
            }
            else
            {
                fixStack(a, vm);
                return vm.GetTop() - vm.RegisterCount() - 1;
            }
        }
        static void fixStack(int a, ILuaVM vm)
        {
            int x = (int)vm.ToInteger(-1);
            vm.Pop(1);

            vm.CheckStack(x - a);
            for (int i = a; i < x; i++)
            {
                vm.PushValue(i);
            }
            vm.Rotate(vm.RegisterCount() + 1, x - a);
        }
        static void popResult(int a, int c, ILuaVM vm)
        {
            if (c == 1)
            {

            }
            else if (c > 1)
            {
                for (int i = a + c - 2; i >= a; i--)
                {
                    vm.Replace(i);
                }
            }
            else
            {
                vm.CheckStack(1);
                vm.PushInteger(a);
            }
        }
        #endregion

        #region Arith
        public static void Add(int i, ILuaVM vm)
        {
            binaryArith(i, vm, ArithOpEnum.LUA_OPADD);
        }
        public static void Sub(int i, ILuaVM vm)
        {
            binaryArith(i, vm, ArithOpEnum.LUA_OPSUB);
        }
        public static void Mul(int i, ILuaVM vm)
        {
            binaryArith(i, vm, ArithOpEnum.LUA_OPMUL);
        }
        public static void Mod(int i, ILuaVM vm)
        {
            binaryArith(i, vm, ArithOpEnum.LUA_OPMOD);
        }
        public static void Pow(int i, ILuaVM vm)
        {
            binaryArith(i, vm, ArithOpEnum.LUA_OPPOW);
        }
        public static void Div(int i, ILuaVM vm)
        {
            binaryArith(i, vm, ArithOpEnum.LUA_OPDIV);
        }
        public static void IDiv(int i, ILuaVM vm)
        {
            binaryArith(i, vm, ArithOpEnum.LUA_OPIDIV);
        }
        public static void Band(int i, ILuaVM vm)
        {
            binaryArith(i, vm, ArithOpEnum.LUA_OPBAND);
        }
        public static void BOr(int i, ILuaVM vm)
        {
            binaryArith(i, vm, ArithOpEnum.LUA_OPBOR);
        }
        public static void BXOr(int i, ILuaVM vm)
        {
            binaryArith(i, vm, ArithOpEnum.LUA_OPBXOR);
        }
        public static void Shl(int i, ILuaVM vm)
        {
            binaryArith(i, vm, ArithOpEnum.LUA_OPSHL);
        }
        public static void Shr(int i, ILuaVM vm)
        {
            binaryArith(i, vm, ArithOpEnum.LUA_OPSHR);
        }
        public static void Unm(int i, ILuaVM vm)
        {
            binaryArith(i, vm, ArithOpEnum.LUA_OPUNM);
        }
        public static void BNot(int i, ILuaVM vm)
        {
            binaryArith(i, vm, ArithOpEnum.LUA_OPBNOT);
        }

        private static void binaryArith(int i, ILuaVM vm, ArithOpEnum op)
        {
            int a = Instruction.GetA(i) + 1;
            int b = Instruction.GetB(i);
            int c = Instruction.GetC(i);
            vm.GetRK(b);
            vm.GetRK(c);
            vm.Arith(op);
            vm.Replace(a);
        }

        private static void unaryArith(int i, ILuaVM vm, ArithOpEnum op)
        {
            int a = Instruction.GetA(i) + 1;
            int b = Instruction.GetB(i) + 1;
            vm.PushValue(b);
            vm.Arith(op);
            vm.Replace(a);
        }
        #endregion
    }
}
