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
            return true;
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
            stack.Set(toIdx, stack.Get(fromIdx));
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
            Rotate(idx, 1);
        }

        public bool IsBoolean(int idx)
        {
            return Type(idx) == LuaValueEnum.LUA_TBOOLEAN;
        }

        public bool IsFunction(int idx)
        {
            return Type(idx) == LuaValueEnum.LUA_TFUNCTION;
        }

        public bool IsInteger(int idx)
        {
            //return typeof(stack.Get(idx)) == typeof(int);
            return false;
        }

        public bool IsNil(int idx)
        {
            return Type(idx) == LuaValueEnum.LUA_TNIL;
        }

        public bool IsNone(int idx)
        {
            return Type(idx) == LuaValueEnum.LUA_TNONE;
        }

        public bool IsNoneOrNil(int idx)
        {
            LuaValueEnum t = Type(idx);
            return t == LuaValueEnum.LUA_TNONE || t == LuaValueEnum.LUA_TNIL;
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
            for(int i = 0; i < n; i++)
            {
                stack.Pop();
            }
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
            stack.Push(stack.Get(idx));
        }

        public void Remove(int idx)
        {
            Rotate(idx, -1);
            Pop(1);
        }

        public void Replace(int idx)
        {
            stack.Set(idx, stack.Pop());
        }

        public void Rotate(int idx, int n)
        {
            int t = stack.Top() - 1;
            int p = stack.AbsIndex(idx) - 1;
            int m = n >= 0 ? t - n : p - n - 1;

            stack.Reverse(p, m);
            stack.Reverse(m + 1, t);
            stack.Reverse(p, t);
        }

        public void SetTop(int idx)
        {
            int newTop = stack.AbsIndex(idx);
            if(newTop < 0)
            {
                Console.WriteLine($"Error Occur");
            }
            int n = stack.Top() - newTop;
            if(n > 0)
            {
                for(int i = 0; i < n; i++)
                {
                    stack.Pop();
                }
            }
            else if(n < 0)
            {
                for(int i = 0; i < n; i++)
                {
                    stack.Push(null);
                }
            }
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
            return stack.IsValid(idx) ? 
                LuaValue.TypeOf(stack.Get(idx)) : LuaValueEnum.LUA_TNONE;
        }

        public string TypeName(LuaValueEnum type)
        {
            switch(type)
            {
                case LuaValueEnum.LUA_TNONE:
                    return "no value";
                case LuaValueEnum.LUA_TNIL:
                    return "";
                case LuaValueEnum.LUA_TBOOLEAN:
                    return "";
                case LuaValueEnum.LUA_TNUMBER:
                    return "";
                case LuaValueEnum.LUA_TSTRING:
                    return "";
                case LuaValueEnum.LUA_TTABLE:
                    return "";
                case LuaValueEnum.LUA_TFUNCTION:
                    return "";
                case LuaValueEnum.LUA_TTHREAD:
                    return "";
                default:
                    return "";
            }
        }
    }
}
