using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    public interface ILuaValue
    {
        string TypeName(LuaValueEnum type);
        LuaValueEnum Type(int idx);
        bool IsNone(int idx);
        bool IsNil(int idx);
        bool IsNoneOrNil(int idx);
        bool IsBoolean(int idx);
        bool IsInteger(int idx);
        bool IsNumber(int idx);
        bool IsString(int idx);
        bool IsTable(int idx);
        bool IsThread(int idx);
        bool IsFunction(int idx);
        bool ToBoolean(int idx);
        long ToInteger(int idx);
        long ToIntegerX(int idx);
        double? ToNumber(int idx);
        double? ToNumberX(int idx);
        string ToString(int idx);
    }
}
