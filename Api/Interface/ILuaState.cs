using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    public interface ILuaState
    {
        int GetTop();
        int AbsIndex(int idx);
        bool CheckStack(int n);
        void Pop(int n);
        void Copy(int fromIdx, int toIdx);
    }
}
