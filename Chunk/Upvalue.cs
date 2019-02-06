using System;
using System.Collections.Generic;
using System.Text;

namespace Chunk
{
    public class Upvalue
    {
        public byte Instack { get; set; }
        public byte Idx { get; set; }

        public void Read(BuffReader reader)
        {
            Instack = reader.ReadByte();
            Idx = reader.ReadByte();
        }
    }
}
