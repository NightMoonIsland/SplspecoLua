using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    public enum ThreadStatus
    {
        LUA_OK,
        LUA_YIELD,
        LUA_ERRRUN,
        LUA_ERRSYNTAX,
        LUA_ERRMEM,
        LUA_ERRGCMM,
        LUA_ERRERR,
        LUA_ERRFILE,
    }
}
