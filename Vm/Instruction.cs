using System;
using System.Collections.Generic;
using System.Text;

namespace Vm
{
    public class Instruction
    {
        public static OpCode getOpCode(int i)
        {
            return OpCode.codes[i & 0x3F];
        }

        public static int getA(int i)
        {
            return (i >> 6) & 0xFF;
        }

        public static int getC(int i)
        {
            return (i >> 14) & 0x1FF;
        }

        public static int getB(int i)
        {
            return (i >> 23) & 0x1FF;
        }

        public static int getBx(int i)
        {
            return (i >> 14);
        }

        public static int getSBx(int i)
        {
            return (i >> 14);
        }

        public static int getAx(int i)
        {
            return (i >> 6);
        }
    }
}
