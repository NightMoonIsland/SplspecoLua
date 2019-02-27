using Chunk;
using System;
using System.Collections.Generic;
using System.Text;

namespace State
{
    public class Closure
    {
        public Prototype Proto { get; private set; }

        public Closure(Prototype proto)
        {
            this.Proto = proto;
        }
    }
}
