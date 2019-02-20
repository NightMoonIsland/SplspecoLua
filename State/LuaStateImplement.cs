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
            return stack.AbsIndex(idx);
        }

        public void AddPC()
        {
            throw new NotImplementedException();
        }

        public void AddPC(int n)
        {
            throw new NotImplementedException();
        }

        public void Arith(ArithOpEnum op)
        {
            throw new NotImplementedException();
        }

        public bool CheckStack(int n)
        {
            throw new NotImplementedException();
        }

        public bool Compare(int idx1, int idx2, CmpOpEnum op)
        {
            throw new NotImplementedException();
        }

        public void Concat(int n)
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
            return stack.Top();
        }

        public void Insert(int idx)
        {
            throw new NotImplementedException();
        }

        public bool IsBoolean(int idx)
        {
            throw new NotImplementedException();
        }

        public bool IsFunction(int idx)
        {
            throw new NotImplementedException();
        }

        public bool IsInteger(int idx)
        {
            throw new NotImplementedException();
        }

        public bool IsNil(int idx)
        {
            throw new NotImplementedException();
        }

        public bool IsNone(int idx)
        {
            throw new NotImplementedException();
        }

        public bool IsNoneOrNil(int idx)
        {
            throw new NotImplementedException();
        }

        public bool IsNumber(int idx)
        {
            throw new NotImplementedException();
        }

        public bool IsString(int idx)
        {
            throw new NotImplementedException();
        }

        public bool IsTable(int idx)
        {
            throw new NotImplementedException();
        }

        public bool IsThread(int idx)
        {
            throw new NotImplementedException();
        }

        public void Len(int idx)
        {
            throw new NotImplementedException();
        }

        public void Pop(int n)
        {
            throw new NotImplementedException();
        }

        public void PushBoolean(bool b)
        {
            throw new NotImplementedException();
        }

        public void PushInteger(long n)
        {
            throw new NotImplementedException();
        }

        public void PushNil()
        {
            throw new NotImplementedException();
        }

        public void PushNumber(double d)
        {
            throw new NotImplementedException();
        }

        public void PushString(string s)
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

        public void SetTop(int idx)
        {
            throw new NotImplementedException();
        }

        public bool ToBoolean(int idx)
        {
            throw new NotImplementedException();
        }

        public long ToInteger(int idx)
        {
            throw new NotImplementedException();
        }

        public long ToIntegerX(int idx)
        {
            throw new NotImplementedException();
        }

        public double ToNumber(int idx)
        {
            throw new NotImplementedException();
        }

        public double ToNumberX(int idx)
        {
            throw new NotImplementedException();
        }

        public string ToString(int idx)
        {
            throw new NotImplementedException();
        }

        public LuaValueEnum Type(int idx)
        {
            throw new NotImplementedException();
        }

        public string TypeName(LuaValueEnum type)
        {
            throw new NotImplementedException();
        }
    }
}
