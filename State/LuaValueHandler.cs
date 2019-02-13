using System;
using System.Collections.Generic;
using System.Text;

namespace State
{
    public class LuaValueHandler
    {
        public static LuaValueTypeEnum Typeof(Object val)
        {
            if(val == null)
            {
                return LuaValueTypeEnum.LUA_TNIL;
            }
            else if(val.GetType() == typeof(bool))
            {
                return LuaValueTypeEnum.LUA_TBOOLEAN;
            }
            else if(val.GetType() == typeof(long) || val.GetType() == typeof(double))
            {
                return LuaValueTypeEnum.LUA_TNUMBER;
            }
            else if(val.GetType() == typeof(string))
            {
                return LuaValueTypeEnum.LUA_TSTRING;
            }
            else
            {
                return LuaValueTypeEnum.LUA_TNIL;
            }
        }
    }
}
