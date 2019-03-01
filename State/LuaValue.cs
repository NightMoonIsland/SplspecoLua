using Api;
using Base;
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
            else if(TypeExtension.TypeEqual<bool>(val))
            {
                return LuaValueEnum.LUA_TBOOLEAN;
            }
            else if(TypeExtension.TypeEqual<long>(val) 
                || TypeExtension.TypeEqual<double>(val))
            {
                return LuaValueEnum.LUA_TNUMBER;
            }
            else if(TypeExtension.TypeEqual<string>(val))
            {
                return LuaValueEnum.LUA_TSTRING;
            }
            else if(TypeExtension.TypeEqual<Closure>(val))
            {
                return LuaValueEnum.LUA_TFUNCTION;
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
            else if(TypeExtension.TypeEqual<bool>(val))
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
            if(TypeExtension.TypeEqual<double>(val))
            {
                return (double)val;
            }
            else if(TypeExtension.TypeEqual<long>(val))
            {
                return Convert.ToDouble(((long)val));
            }
            else if(TypeExtension.TypeEqual<string>(val))
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
            if(TypeExtension.TypeEqual<long>(val))
            {
                return (long)val;
            }
            else if(TypeExtension.TypeEqual<double>(val))
            {
                double n = (double)val;
                return LuaNumber.IsInteger(n) ? (long?)n : null; 
            }
            else if(TypeExtension.TypeEqual<string>(val))
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
