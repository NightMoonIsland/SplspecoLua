using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    public interface ILuaVM : ILuaState, ILuaLFunction
    {
        int PC();
        int GetPC();
        void AddPC(int n);
        int Fetch();
        void GetConst(int idx);
        void GetRK(int rk);
    }
}
