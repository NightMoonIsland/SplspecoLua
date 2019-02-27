using Api;
using State;
using System;

namespace TestLuaApi
{
    class Program
    {
        static void Main(string[] args)
        {
            ILuaState ls = new LuaStateImplement();
            ls.PushBoolean(true);
            printStack(ls);
            ls.PushInteger(1024);
            printStack(ls);
            ls.PushString("Wocao");
            printStack(ls);
            ls.PushNumber(233.444);
            printStack(ls);
        }

        private static void printStack(ILuaState ls)
        {
            Console.WriteLine("");
            int top = ls.GetTop();
            for(int i = 1; i <= top; i++)
            {
                LuaValueEnum t = ls.Type(i);
                switch(t)
                {
                    case LuaValueEnum.LUA_TBOOLEAN:
                        {
                            Console.WriteLine(string.Format("[{0}]", ls.ToBoolean(i)));
                        }
                        break;
                    case LuaValueEnum.LUA_TNUMBER:
                        {
                            if(ls.IsInteger(i))
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
