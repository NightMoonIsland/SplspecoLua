using System;
using System.Collections.Generic;

namespace Stack
{
    public class LuaStack
    {
        private List<object> slots = new List<object>();

        public int Top()
        {
            return slots.Count;
        }
    }
}
