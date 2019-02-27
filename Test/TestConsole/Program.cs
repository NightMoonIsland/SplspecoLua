using System;
using Vm;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"OpCode Len {OpCode.codes.Length}");
            for(int i = 0; i < OpCode.codes.Length; i++)
            {
                int idx = (int)OpCode.codes[i].Type;
                //OpCode.codes[i].type == OpCode.codes[i].type.ToString()
                Console.WriteLine($"Code Idx {idx} {OpCode.codes[i].Type} {OpCode.codes[i].Type.ToString()}");
                if(idx != i)
                {
                    Console.WriteLine($"Idx {i} Not Equal");
                }
            }
            Console.WriteLine("Hello World!");
        }
    }
}
