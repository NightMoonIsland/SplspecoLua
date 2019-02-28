using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    public interface ILuaState : ILuaTable, ILuaStack, ILuaValue
    {
        void PushNil();
        void PushBoolean(bool b);
        void PushInteger(long n);
        void PushNumber(double d);
        void PushString(string s);

        void Arith(ArithOpEnum op);
        bool Compare(int idx1, int idx2, CmpOpEnum op);

        void Len(int idx);
        void Concat(int n);

        ThreadStatusEnum Load(byte[] chunk, string chunkName, string mode);
        void Call(int nArgs, int nResults);
    }
}
