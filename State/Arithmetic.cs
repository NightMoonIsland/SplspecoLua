using Number;
using System;
using System.Collections.Generic;
using System.Text;

using LongBinaryOperator = System.Func<long, long, long>;
using DoubleBinaryOperator = System.Func<double, double, double>;

namespace State
{
    class Arithmetic
    {
        static readonly LongBinaryOperator[] integerOps =
        {
            (a, b) => { return a + b; },
            (a, b) => { return a - b; },
            (a, b) => { return a * b; },
            LuaMath.LongMod,
            null,
            null,
            LuaMath.LongDiv,
            (a, b) => { return a & b; },
            (a, b) => { return a | b; },
            (a, b) => { return a ^ b; },
            LuaMath.ShiftLeft,
            LuaMath.ShiftRight,
            (a, b) => { return -a; },
            (a, b) => { return ~a; },
        };

        static readonly DoubleBinaryOperator[] floatOps =
        {
            (a, b) => { return a + b; },
            (a, b) => { return a - b; },
            (a, b) => { return a * b; },
            LuaMath.FloorMod,
            LuaMath.Pow,
            (a, b) => { return a / b; },
            LuaMath.FloorDiv,
            null,
            null,
            null,
            null,
            null,
            (a, b) => { return -a; },
            null,
        };

        public static Object Arith(Object a, Object b, ArithOp op)
        {
            LongBinaryOperator integerFunc = integerOps[(int)op];
            DoubleBinaryOperator floatFunc = floatOps[(int)op];
            if(floatFunc == null)
            {
                long? x = LuaValue.ToInteger(a);
                if(x != null)
                {
                    long? y = LuaValue.ToInteger(b);
                    if(y != null)
                    {
                        return integerFunc((long)x, (long)y);
                    }
                }
            }
            else
            {

            }
            return null;
        }
    }
}
