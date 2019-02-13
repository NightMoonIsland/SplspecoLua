using System;
using System.Collections.Generic;
using System.Text;

namespace State
{
    public interface ILuaVM : ILuaState
    {
        int PC { get; set; }

        int GetPC();
        void AddPC();
        int Fetch();
        void GetConst(int idx);
        void GetRK(int rk);
    }
}
