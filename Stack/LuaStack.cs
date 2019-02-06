using System;
using System.Collections.Generic;

namespace Stack
{
    public class LuaStack
    {
        const int MAX_OBJECT_NUM = 10000;

        private List<object> slots = new List<object>();

        public int Top()
        {
            return slots.Count;
        }

        public void Push(object val)
        {
            if(slots.Count > MAX_OBJECT_NUM)
            {
                return;
            }
            slots.Add(val);
        }


    }
}
