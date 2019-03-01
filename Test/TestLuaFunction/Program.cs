using Chunk;
using System;
using System.IO;
using Api;
using State;

namespace TestLuaFunction
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
                ILuaState ls = new LuaStateImplement();
                ls.Load(data, args[0], "b");
                ls.Call(0, 0);
                //Prototype proto = BinaryChunk.Undump(data);
            }
        }
    }
}
