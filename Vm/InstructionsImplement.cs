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
    }
}
