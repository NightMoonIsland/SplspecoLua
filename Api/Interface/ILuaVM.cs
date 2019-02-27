using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    public interface ILuaVM : ILuaState
    {
        int PC { get; }
        int GetPC();
        void AddPC(int n);
        int Fetch();
        void GetConst(int idx);
        void GetRK(int rk);
        int RegisterCount();
        void LoadVararg(int n);
        void LoadProto(int idx);
    }
}
