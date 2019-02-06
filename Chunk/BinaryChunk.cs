using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chunk
{
    public struct Const
    {
        public const string LUA_SIGNATURE = "";
        public const int LUAC_VERSION = 0x53;
        public const int LUAC_FORMAT = 0;
        public const string LUAC_DATA = "\x19\x93\r\n\x1a\n";
        public const int CINT_SIZE = 4;
        public const int CSZIET_SIZE = 8;
    }

    public class BinaryChunk
    {
        private static readonly byte[] LUA_SIGNATURE = { 0x1b, (byte)'L', (byte)'u', (byte)'a' };
        private static readonly int LUAC_VERSION = 0x53;
        private static readonly int LUAC_FORMAT = 0;
        private static readonly byte[] LUAC_DATA = { 0x19, (byte)0x93, (byte)'\r', (byte)'\n', 0x1a, (byte)'\n' };
        private static readonly int CINT_SIZE = 4;
        private static readonly int CSZIET_SIZE = 4;
        private static readonly int INSTRUCTION_SIZE = 4;
        private static readonly int LUA_INTEGER_SIZE = 8;
        private static readonly int LUA_NUMBER_SIZE = 8;
        private static readonly int LUAC_INT = 0x5678;
        private static readonly double LUAC_NUM = 370.5;

        public static Prototype Undump(byte[] data)
        {
            BuffReader reader = new BuffReader(data);
            checkHead(reader);
            reader.ReadByte();
            Prototype mainFunc = new Prototype();
            mainFunc.Read(reader, "");
            return mainFunc;
        }

        static void checkHead(BuffReader buf)
        {
            if(!Enumerable.SequenceEqual(LUA_SIGNATURE, buf.ReadBytes(4)))
            {
                Console.WriteLine("!Array.Equals(LUA_SIGNATURE, buf.ReadBytes(4))");
                for(int i = 0; i < 4; i++)
                {
                    Console.WriteLine($"byte {i}: {LUA_SIGNATURE[i]}");
                }
                return;
            }

            if(buf.ReadByte() != LUAC_VERSION)
            {
                Console.WriteLine($"Version {LUAC_VERSION}");
                Console.WriteLine("buf.ReadByte() != LUAC_VERSION");
            }

            if(buf.ReadByte() != LUAC_FORMAT)
            {
                Console.WriteLine("buf.ReadByte() != LUAC_FORMAT");
            }

            if(!Enumerable.SequenceEqual(LUAC_DATA, buf.ReadBytes(6)))
            {
                Console.WriteLine("!Enumerable.SequenceEqual(LUAC_DATA, buf.ReadBytes(6))");
            }

            if(buf.ReadByte() != CINT_SIZE)
            {
                Console.WriteLine("buf.ReadByte() != CINT_SIZE");
            }

            if(buf.ReadByte() != CSZIET_SIZE)
            {
                Console.WriteLine($"CSZIET_SIZE {CSZIET_SIZE}");
                Console.WriteLine("buf.ReadByte() != CSZIET_SIZE");
            }

            if(buf.ReadByte() != INSTRUCTION_SIZE)
            {
                Console.WriteLine("buf.ReadByte() != INSTRUCTION_SIZE");
            }

            if(buf.ReadByte() != LUA_INTEGER_SIZE)
            {
                Console.WriteLine("buf.ReadByte() != LUA_INTEGER_SIZE");
            }

            if(buf.ReadByte() != LUA_NUMBER_SIZE)
            {
                Console.WriteLine("buf.ReadByte() != LUA_NUMBER_SIZE");
            }

            if(buf.ReadInt64() != LUAC_INT)
            {
                Console.WriteLine("buf.ReadInt64() != LUAC_INT");
            }

            if(buf.ReadDouble() != LUAC_NUM)
            {
                Console.WriteLine("buf.ReadDouble() != LUAC_NUM");
            }
        }
    }
}
