using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    public enum ArithOpEnum
    {
        LUA_OPADD, // +
        LUA_OPSUB, // -
        LUA_OPMUL, // *
        LUA_OPMOD, // %
        LUA_OPPOW, // ^
        LUA_OPDIV, // /
        LUA_OPIDIV, // //
        LUA_OPBAND, // &
        LUA_OPBOR, // |
        LUA_OPBXOR, // ~
        LUA_OPSHL, // <<
        LUA_OPSHR, // >>
        LUA_OPUNM, // -
        LUA_OPBNOT, // ~
    }
}
