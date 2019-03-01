using System;
using System.Collections.Generic;
using System.Text;

namespace Base
{
    public class Fpb
    {
        public static int Int2Fb(int x)
        {
            int e = 0;
            if(x < 8)
            {
                return x;
            }

            while(x >= (8 << 4)) //coarse steps
            {
                x = (x + 0xf) >> 4;
                e += 4;
            }

            while(x >= (8 << 1)) //fine steps
            {
                x = (x + 1) >> 1;
                e++;
            }

            return ((e + 1) << 3) | (x - 8);
        }

        public static int Fb2Int(int x)
        {
            if(x < 8)
            {
                return x;
            }
            else
            {
                return ((x & 7) + 8) << ((x >> 3) - 1);
            }
        }
    }
}
