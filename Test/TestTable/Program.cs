using Api;
using Chunk;
using State;
using System;
using System.IO;
using Vm;

namespace TestTable
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string path = Path.GetFullPath(args[0]);
                Console.WriteLine($"path {path}");
                byte[] data = File.ReadAllBytes(Path.GetFullPath(args[0]));
                Prototype proto = BinaryChunk.Undump(data);
                luaMain(proto);
            }
        }

        public static void luaMain(Prototype proto)
        {
            ILuaVM vm = new LuaStateImplement(proto);
            vm.SetTop(proto.MaxStackSize);
            for (; ; )
            {
                int pc = vm.GetPC();
                int i = vm.Fetch();
                OpCode opCode = Instruction.GetOpCode(i);
                if (opCode.NotEqual(OpCodeEnum.OP_RETURN))
                {
                    opCode.Action(i, vm);
                    Console.WriteLine(string.Format("[{0}] {1}", pc + 1, opCode.ToString()));
                    printStack(vm);
                }
                else
                {
                    break;
                }
            }
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
