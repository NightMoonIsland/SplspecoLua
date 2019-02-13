using System;
using System.Collections.Generic;
using System.Text;

namespace Number
{
    public class LuaMath
    {
        public static long ShiftLeft(long a, long n)
        {
            //Undo
            //return n >= 0 ? a << n : a >> -n;
            return n;
        }

        public static long ShiftRight(long a, long n)
        {
            //Undo
            //Error ">>" can't use in type long.
            //return n >= 0 ? a >> n : a << -n;
            return n;
        }

        public static long LongDiv(long a, long b)
        {
            return a / b;
        }

        public static long LongMod(long a, long b)
        {
            return a % b;
        }

        public static double FloorDiv(double a, double b)
        {
            return Math.Floor(a / b);
        }

        public static double FloorMod(double a, double b)
        {
            if(a > 0 && b == Double.PositiveInfinity ||
                a < 0 && b == Double.NegativeInfinity)
            {
                return a;
            }
            if(a > 0 && b == Double.NegativeInfinity ||
                a < 0 && b == Double.PositiveInfinity)
            {
                return b;
            }
            return a - Math.Floor(a / b) * b;
        }

        public static double Pow(double a, double b)
        {
            return a;
        }
    }
}
