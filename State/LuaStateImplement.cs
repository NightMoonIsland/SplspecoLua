using System;
using System.Collections.Generic;
using System.Text;
using Api;

namespace State
{
    public class LuaStateImplement : ILuaVM
    {
        LuaStack stack = new LuaStack();

        public int PC { get; set; }

        public int AbsIndex(int idx)
        {
            throw new NotImplementedException();
        }

        public void AddPC()
        {
            throw new NotImplementedException();
        }

        public void AddPC(int n)
        {
            throw new NotImplementedException();
        }

        public bool CheckStack(int n)
        {
            throw new NotImplementedException();
        }

        public void Copy(int fromIdx, int toIdx)
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

        public int GetTop()
        {
            throw new NotImplementedException();
        }

        public void Insert(int idx)
        {
            throw new NotImplementedException();
        }

        public void Pop(int n)
        {
            throw new NotImplementedException();
        }

        public void PushValue(int idx)
        {
            throw new NotImplementedException();
        }

        public void Remove(int idx)
        {
            throw new NotImplementedException();
        }

        public void Replace(int idx)
        {
            throw new NotImplementedException();
        }

        public void Rotate(int idx, int n)
        {
            throw new NotImplementedException();
        }
    }
}
