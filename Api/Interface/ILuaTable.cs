using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    public interface ILuaTable
    {
        void NewTable();
        void CreateTable(int nArr, int nRec);
        LuaValueEnum GetTable(int idx);
        LuaValueEnum GetField(int idx, string k);
        LuaValueEnum GetI(int idx, long i);

        void SetTable(int idx);
        void SetField(int idx, string k);
        void SetI(int idx, long i);
    }
}
