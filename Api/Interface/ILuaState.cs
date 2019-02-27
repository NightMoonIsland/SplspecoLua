using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    public interface ILuaState : ILuaTable
    {
        int GetTop();
        int AbsIndex(int idx);
        bool CheckStack(int n);
        void Pop(int n);
        void Copy(int fromIdx, int toIdx);
        void PushValue(int idx);
        void Replace(int idx);
        void Insert(int idx);
        void Remove(int idx);
        void Rotate(int idx, int n);
        void SetTop(int idx);

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

        void PushNil();
        void PushBoolean(bool b);
        void PushInteger(long n);
        void PushNumber(double d);
        void PushString(string s);

        void Arith(ArithOpEnum op);
        bool Compare(int idx1, int idx2, CmpOpEnum op);

        //void NewTable();

        void Len(int idx);
        void Concat(int n);

        ThreadStatus Load(byte[] chunk, string chunkName, string mode);
        void Call(int nArgs, int nResults);
    }
}
