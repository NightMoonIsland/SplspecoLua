using System;
using System.Collections.Generic;
using System.Text;
using Api;

namespace Vm
{
    public class InstructionsImplement
    {
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

        }

        public static void NewTable(int i, ILuaVM vm)
        {
            int a = Instruction.GetA(i) + 1;
            int b = Instruction.GetB(i) + 1;
            int c = Instruction.GetC(i);
            vm.GetRK(c);
        }

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
