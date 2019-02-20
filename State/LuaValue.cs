using Api;
using Number;
using System;
using System.Collections.Generic;
using System.Text;

namespace State
{
    public class LuaValue
    {
        public static LuaValueEnum TypeOf(Object val)
        {
            if(val == null)
            {
                return LuaValueEnum.LUA_TNIL;
            }
            else if(val.GetType() == typeof(bool))
            {
                return LuaValueEnum.LUA_TBOOLEAN;
            }
            else if(val.GetType() == typeof(long) || val.GetType() == typeof(double))
            {
                return LuaValueEnum.LUA_TNUMBER;
            }
            else if(val.GetType() == typeof(string))
            {
                return LuaValueEnum.LUA_TSTRING;
            }
            else
            {
                return LuaValueEnum.LUA_TNIL;
            }
        }

        public static bool ToBoolean(Object val)
        {
            if(val == null)
            {
                return false;
            }
            else if(val.GetType() == typeof(bool))
            {
                return (bool)val;
            }
            else
            {
                return true;
            }
        }

        public static double? ToFloat(Object val)
        {
            if(val.GetType() == typeof(double))
            {
                return (double)val;
            }
            else if(val.GetType() == typeof(long))
            {
                return Convert.ToDouble(((long)val));
            }
            else if(val.GetType() == typeof(string))
            {
                return LuaNumber.ParseDouble((string)val);
            }
            else
            {
                return null;
            }
        }

        public static long? ToInteger(Object val)
        {
            if(val.GetType() == typeof(long))
            {
                return (long)val;
            }
            else if(val.GetType() == typeof(double))
            {
                double n = (double)val;
                return LuaNumber.IsInteger(n) ? (long?)n : null; 
            }
            else if(val.GetType() == typeof(string))
            {
                return ToInteger((string)val);
            }
            else
            {
                return null;
            }
        }

        public static long? ToInteger(string s)
        {
            long? i = LuaNumber.ParseLong(s);
            if(i != null)
            {
                return i;
            }
            double? f = LuaNumber.ParseDouble(s);
            if(f != null && LuaNumber.IsInteger(f))
            {
                return LuaNumber.ParseLong(f);
            }
            else
            {
                return null;
            }
        }
    }
}
