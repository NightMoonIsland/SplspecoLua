using Api;
using Chunk;
using State;
using System;
using System.IO;
using Vm;

namespace TestStack
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
                Console.WriteLine($"byte {data.Length}");
            }
            Console.WriteLine("Hello World!");
        }

        private static void luaMain(Prototype proto)
        {
            ILuaVM vm = new LuaStateImplement();
            vm.SetTop(proto.MaxStackSize);
            for(; ; )
            {
                int pc = vm.GetPC();
                int i = vm.Fetch();
                OpCode opCode = Instruction.GetOpCode(i);
                if(opCode.NotEqual(OpCodeEnum.OP_RETURN))
                {
                    opCode.Action(i, vm);
                    System.Console.WriteLine($"Pc {pc + 1} ,OpcodeName {opCode.Name}");
                    printStack(vm);
                }
                else
                {

                }
            }
        }

        private static void printStack(ILuaState ls)
        {
            int top = ls.GetTop();
            for(int i = 1; i <= top; i++)
            {
            }
        }
    }
}
