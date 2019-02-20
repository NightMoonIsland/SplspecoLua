using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    public enum LuaValueEnum
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
