using System;
using System.Collections.Generic;
using System.Text;
using Base;
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
            if(arr != null && TypeExtension.TypeEqual<long>(key))
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

            key = floatToInt(key);
            if(TypeExtension.TypeEqual<long>(key))
            {
                int idx = Convert.ToInt32((long)key);
                if(idx >= 1)
                {
                    if(arr == null)
                    {
                        arr = new List<Object>();
                    }

                    int arrLen = arr.Count;
                    if(idx <= arrLen)
                    {
                        arr[idx - 1] = val;
                        if (idx == arrLen && val == null)
                        {
                            shrinkArray();
                        }
                        return;
                    }
                    if(idx == arrLen + 1)
                    {
                        if(map != null)
                        {
                            map.Remove(key);
                        }
                        if(val != null)
                        {
                            arr.Add(val);
                            expandArray();
                        }
                        return;
                    }
                }
            }

            if(val != null)
            {
                if(map == null)
                {
                    map = new Dictionary<object, object>();
                }
                map.Add(key, val);
            }
            else
            {
                if(map != null)
                {
                    map.Remove(key);
                }
            }
        }

        private Object floatToInt(Object key)
        {
            if(TypeExtension.TypeEqual<double>(key))
            {
                double f = (double)key;
                if(LuaNumber.IsInteger(f))
                {
                    return Convert.ToInt64(f);
                }
            }
            return key;
        }

        private void shrinkArray()
        {
            for(int i = arr.Count - 1; i >= 0; i--)
            {
                if(arr[i] == null)
                {
                    arr.RemoveAt(i);
                }
            }
        }

        private void expandArray()
        {
            if(map != null)
            {
                for(int idx = arr.Count + 1; ; idx++)
                {
                    Object val = map.Remove((long)idx);
                    if(val != null)
                    {
                        arr.Add(val);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
