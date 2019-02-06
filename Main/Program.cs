using System;
using System.IO;
using Chunk;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length > 0)
            {
                string path = Path.GetFullPath(args[0]);
                Console.WriteLine($"path {path}");
                byte[] data = File.ReadAllBytes(Path.GetFullPath(args[0]));
                Prototype proto = BinaryChunk.Undump(data);
                Console.WriteLine($"byte {data.Length}");
            }
            Console.WriteLine("Hello World!");
        }
    }
}
