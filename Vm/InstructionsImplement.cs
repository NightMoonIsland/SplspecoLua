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
            int a = Instruction.getA(i);
            int b = Instruction.getB(i);
            vm.Copy(b, a);
        }

        public static void Jmp(int i, ILuaVM vm)
        {
            int a = Instruction.getA(i);
            int sBx = Instruction.getSBx(i);
            vm.AddPC(sBx);
            if(a != 0)
            {
                throw new Exception("Jmp: a != 0");
            }
        }

        public static void LoadNil(int i, ILuaVM vm)
        {

        }
    }
}
