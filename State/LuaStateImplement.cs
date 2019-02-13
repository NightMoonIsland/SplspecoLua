using System;
using System.Collections.Generic;
using System.Text;

namespace State
{
    public class LuaStateImplement : ILuaState, ILuaVM
    {
        LuaStack stack = new LuaStack();

        public void AddPC()
        {
            throw new NotImplementedException();
        }

        public int Fetch()
        {
            throw new NotImplementedException();
        }

        public void GetConst(int idx)
        {
            throw new NotImplementedException();
        }

        public int GetPC()
        {
            throw new NotImplementedException();
        }

        public void GetRK(int rk)
        {
            throw new NotImplementedException();
        }
    }
}
