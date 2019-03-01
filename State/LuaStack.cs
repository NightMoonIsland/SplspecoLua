using System;
using System.Collections.Generic;

namespace State
{
    public class LuaStack
    {
        const int MAX_OBJECT_NUM = 10000;

        private List<object> slots = new List<object>();


        public Closure Closure { get; set; }
        public List<Object> Varargs { get; set; }
        public int PC { get; set; }

        public LuaStack Prev { get; set; }

        public int Top()
        {
            return slots.Count;
        }

        public void Push(object val)
        {
            if(slots.Count > MAX_OBJECT_NUM)
            {
                Console.WriteLine("stack Error:Reach MAX_OBJECT_NUM");
                return;
            }
            slots.Add(val);
        }

        public void PushN(List<Object> vals, int n)
        {
            int nVals = vals == null ? 0 : vals.Count;
            if(n < 0)
            {
                n = nVals;
            }
            for(int i = 0; i < n; i++)
            {
                Push(i < nVals ? vals[i] : null);
            }
        }

        public Object Pop()
        {
            int _count = slots.Count;
            Object ret = slots[_count - 1];
            slots.RemoveAt(_count - 1);
            return ret;
        }

        public List<Object> PopN(int n)
        {
            List<Object> vals = new List<Object>(n);
            for(int i = 0; i < n; i++)
            {
                vals.Add(Pop());
            }
            vals.Reverse();
            return vals;
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
