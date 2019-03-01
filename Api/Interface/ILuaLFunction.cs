using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    public interface ILuaLFunction
    {
        int RegisterCount();
        void LoadVararg(int n);
        void LoadProto(int idx);
    }
}
