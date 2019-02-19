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

        }

        private static void binaryArith(int i, ILuaVM vm, ArithOpEnum op)
        {
            int a = Instruction.GetA(i) + 1;
            int b = Instruction.GetB(i) + 1;
            vm.PushValue(b);
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
