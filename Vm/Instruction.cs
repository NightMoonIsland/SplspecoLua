using System;
using System.Collections.Generic;
using System.Text;

namespace Vm
{
    public class Instruction
    {
        public static OpCode GetOpCode(int i)
        {
            return OpCode.codes[i & 0x3F];
        }

        public static void GetABC
            (int i, out int a, out int b, out int c)
        {
            a = GetA(i);
            b = GetB(i);
            c = GetC(i);
        }

        public static int GetA(int i)
        {
            return (i >> 6) & 0xFF;
        }

        public static int GetC(int i)
        {
            return (i >> 14) & 0x1FF;
        }

        public static int GetB(int i)
        {
            return (i >> 23) & 0x1FF;
        }

        public static int GetBx(int i)
        {
            return (i >> 14);
        }

        public static int GetSBx(int i)
        {
            return (i >> 14);
        }

        public static int GetAx(int i)
        {
            return (i >> 6);
        }
    }
}
