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
            vm.SetTop(proto.maxStackSize);
            for(; ; )
            {
                int pc = vm.GetPC();
                int i = vm.Fetch();
                OpCode opCode = Instruction.GetOpCode(i);
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
