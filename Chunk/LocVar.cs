using System;
using System.Collections.Generic;
using System.Text;

namespace Chunk
{
    public class LocVar
    {
        public string VarName { get; private set; }
        public int StartPc { get; private set; }
        public int EndPc { get; private set; }

        public void Read(BuffReader buf)
        {
            VarName = buf.ReadLuaString();
            StartPc = buf.ReadInt32();
            EndPc = buf.ReadInt32();
        }
    }
}
