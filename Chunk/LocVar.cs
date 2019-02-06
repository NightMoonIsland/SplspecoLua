using System;
using System.Collections.Generic;
using System.Text;

namespace Chunk
{
    public class LocVar
    {
        string varName;
        int startPc;
        int endPc;

        public void Read(BuffReader buf)
        {
            varName = buf.ReadLuaString();
            startPc = buf.ReadInt32();
            endPc = buf.ReadInt32();
        }
    }
}
