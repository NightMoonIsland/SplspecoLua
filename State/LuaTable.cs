using System;
using System.Collections.Generic;
using System.Text;
using Number;

namespace State
{
    public class LuaTable
    {
        private List<Object> arr;
        private Dictionary<Object, Object> map;

        public LuaTable(int nArr, int nMap)
        {
            if(nArr > 0)
            {
                arr = new List<Object>(nArr);
            }
            if(nMap > 0)
            {
                map = new Dictionary<Object, Object>(nMap);
            }
        }

        public int Length()
        {
            return arr == null ? 0 : arr.Count;
        }

        public Object Get(Object key)
        {
            key = floatToInt(key);
            if(arr != null && key.GetType() == typeof(long))
            {
                int idx = Convert.ToInt32((long)key);
                if(idx >= 1 && idx <= arr.Count)
                {
                    return arr[idx - 1];
                }
            }
            return map != null && map.ContainsKey(key) ? map[key] : null;
        }

        public void Put(Object key, Object val)
        {
        }

        private Object floatToInt(Object key)
        {
            if(key.GetType() == typeof(double))
            {
                double f = (double)key;
                if(LuaNumber.IsInteger(f))
                {
                    return Convert.ToInt64(f);
                }
            }
            return key;
        }
    }
}
