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

        public Object Pop()
        {
            int _count = slots.Count;
            Object ret = slots[_count - 1];
            slots.RemoveAt(_count - 1);
            return ret;
        }

        public int AbsIndex(int idx)
        {
            return idx >= 0 ? idx : idx + slots.Count + 1;
        }

        public bool IsValid(int idx)
        {
            int absIdx = AbsIndex(idx);
            return absIdx > 0 && absIdx <= slots.Count;
        }

        public Object Get(int idx)
        {
            int absIdx = AbsIndex(idx);
            if(absIdx > 0 && absIdx <= slots.Count)
            {
                return slots[absIdx - 1];
            }
            else
            {
                return null;
            }
        }

        public void Set(int idx, Object obj)
        {
            int absIdx = AbsIndex(idx);
            slots.Insert(absIdx - 1, obj);
        }

        public void Reverse(int from, int to)
        {
            slots.Reverse(from, to - from + 1);
        }
    }
}
