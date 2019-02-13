using System;
using System.Collections.Generic;
using System.Text;

namespace State
{
    public enum LuaValueTypeEnum
    {
        LUA_TNIL,
        LUA_TBOOLEAN,
        LUA_TLIGHTUSERDATA,
        LUA_TNUMBER,
        LUA_TSTRING,
        LUA_TTABLE,
        LUA_TFUNCTION,
        LUA_TUSERDATA,
        LUA_TTHREAD,
        LUA_TNONE,
    }
}
