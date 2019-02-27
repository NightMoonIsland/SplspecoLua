using Api;
using System;
using Chunk;
using State;

namespace TestArith
{
    class Program
    {
        static void Main(string[] args)
        {
            ILuaState ls = new LuaStateImplement();
            ls.PushInteger(2);
            ls.PushString("2.0");
            ls.PushString("3.0");
            ls.PushNumber(4.0);
            printStack(ls);

            ls.Arith(ArithOpEnum.LUA_OPADD);
            printStack(ls);
            ls.Arith(ArithOpEnum.LUA_OPSUB);
            printStack(ls);
        }


        private static void printStack(ILuaState ls)
        {
            Console.WriteLine("");
            int top = ls.GetTop();
            for (int i = 1; i <= top; i++)
            {
                LuaValueEnum t = ls.Type(i);
                switch (t)
                {
                    case LuaValueEnum.LUA_TBOOLEAN:
                        {
                            Console.WriteLine(string.Format("[{0}]", ls.ToBoolean(i)));
                        }
                        break;
                    case LuaValueEnum.LUA_TNUMBER:
                        {
                            if (ls.IsInteger(i))
                            {
                                Console.WriteLine(string.Format("[{0}]", ls.ToInteger(i)));
                            }
                            else
                            {
                                Console.WriteLine(string.Format("[{0}]", ls.ToNumber(i)));
                            }
                        }
                        break;
                    case LuaValueEnum.LUA_TSTRING:
                        {
                            Console.WriteLine(string.Format("[{0}]", ls.ToString(i)));
                        }
                        break;
                    default:
                        {

                        }
                        break;
                }
            }
        }
    }
}
