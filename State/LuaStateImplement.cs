using System;
using System.Collections.Generic;
using System.Text;
using Api;
using Base;
using Chunk;
using Vm;

namespace State
{
    public class LuaStateImplement : ILuaVM
    {
        LuaStack stack = new LuaStack();
        Prototype proto;
        int pc;

        public LuaStateImplement()
        {
            proto = null;
        }
        public LuaStateImplement(Prototype proto)
        {
            this.proto = proto;
        }

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
            pc += n;
        }

        public int PC()
        {
            return stack.PC;
        }

        public void Arith(ArithOpEnum op)
        {
            Object b = stack.Pop();
            Object a = 
                op != ArithOpEnum.LUA_OPUNM && 
                op != ArithOpEnum.LUA_OPBNOT ? stack.Pop() : b;
            Object result = Arithmetic.Arith(a, b, op);
            if(result != null)
            {
                stack.Push(result);
            }
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

        public int GetPC()
        {
            return pc;
        }

        public int Fetch()
        {
            return proto.Code[pc++];
        }

        public void GetConst(int idx)
        {
            stack.Push(proto.Constants[idx]);
        }

        public void GetRK(int rk)
        {
            if(rk > 0xFF)
            {
                GetConst(rk & 0xFF);
            }
            else
            {
                PushValue(rk + 1);
            }
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
            return TypeExtension.TypeEqual<int>(stack.Get(idx));
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
            stack.Push(b);
        }

        public void PushInteger(long n)
        {
            stack.Push(n);
        }

        public void PushNil()
        {
            stack.Push(null);
        }

        public void PushNumber(double d)
        {
            stack.Push(d);
        }

        public void PushString(string s)
        {
            stack.Push(s);
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
            return LuaValue.ToBoolean(stack.Get(idx));
        }

        public long ToInteger(int idx)
        {
            throw new NotImplementedException();
        }

        public long ToIntegerX(int idx)
        {
            throw new NotImplementedException();
        }

        public double? ToNumber(int idx)
        {
            double? n = ToNumberX(idx);
            return n == null ? 0 : n;
        }

        public double? ToNumberX(int idx)
        {
            Object val = stack.Get(idx);
            if(TypeExtension.TypeEqual<double>(val))
            {
                return (double)val;
            }
            else if(TypeExtension.TypeEqual<long>(val))
            {
                return Convert.ToDouble(((long)val));
            }
            else
            {
                return null;
            }
        }

        public string ToString(int idx)
        {
            Object val = stack.Get(idx);
            if(TypeExtension.TypeEqual<string>(val))
            {
                return (string)val;
            }
            else if(TypeExtension.TypeEqual<long>(val) 
                    || TypeExtension.TypeEqual<double>(val))
            {
                return val.ToString();
            }
            else
            {
                return null;
            }
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

        private void pushLuaStack(LuaStack newTop)
        {
            newTop.Prev = this.stack;
            this.stack = newTop;
        }
        private void popLuaStack()
        {
            LuaStack top = this.stack;
            this.stack = top.Prev;
            top.Prev = null;
        }

        public ThreadStatusEnum Load(byte[] chunk, string chunkName, string mode)
        {
            Prototype proto = BinaryChunk.Undump(chunk);
            stack.Push(new Closure(proto));
            return ThreadStatusEnum.LUA_OK;
        }

        public void Call(int nArgs, int nResults)
        {
            Object val = stack.Get(-(nArgs + 1));
            if(TypeExtension.TypeEqual<Closure>(val))
            {
                Closure c = (Closure)val;
                Console.WriteLine("");
                callLuaClosure(nArgs, nResults, c);
            }
            else
            {
                throw new Exception("val is not a Closure");
            }
        }

        private void callLuaClosure(int nArgs, int nResults, Closure c)
        {
            int nRegs = c.Proto.MaxStackSize;
            int nParams = c.Proto.NumParams;
            bool isVararg = c.Proto.IsVararg == 1;

            LuaStack newStack = new LuaStack();
            newStack.Closure = c;

            List<Object> funcAndArgs = stack.PopN(nArgs + 1);
            newStack.PushN(funcAndArgs.GetRange(1, funcAndArgs.Count - 1), nParams);
            if(nArgs > nParams && isVararg)
            {
                newStack.Varargs = funcAndArgs.GetRange(nParams + 1, funcAndArgs.Count);
            }

            pushLuaStack(newStack);
            SetTop(nRegs);
            runLuaClosure();
            popLuaStack();

            if(nResults != 0)
            {
                List<Object> results = newStack.PopN(stack.Top() - nRegs);
                stack.PushN(results, nResults);
            }
        }

        private void runLuaClosure()
        {
            for(; ; )
            {
                int i = Fetch();
                OpCode opCode = Instruction.GetOpCode(i);
                opCode.Action(i, this);
                if(opCode.Equals(OpCodeEnum.OP_RETURN))
                {
                    break;
                }
            }
        }

        #region LFunction
        public int RegisterCount()
        {
            return stack.Closure.Proto.MaxStackSize;
        }

        public void LoadVararg(int n)
        {
            List<Object> varargs = stack.Varargs != null ? stack.Varargs : new List<object>();
            if (n < 0)
            {
                n = varargs.Count;
            }
            stack.PushN(varargs, n);
        }

        public void LoadProto(int idx)
        {
            Prototype proto = stack.Closure.Proto.Protos[idx];
            stack.Push(new Closure(proto));
        }
        #endregion

        #region Table
        public void NewTable()
        {
            CreateTable(0, 0);
        }

        public void CreateTable(int nArr, int nRec)
        {
            stack.Push(new LuaTable(nArr, nRec));
        }

        public LuaValueEnum GetTable(int idx)
        {
            Object t = stack.Get(idx);
            Object k = stack.Pop();
            return getTable(t, k);
        }

        LuaValueEnum getTable(Object t, Object k)
        {
            if(TypeExtension.TypeEqual<LuaTable>(t))
            {
                Object v = ((LuaTable)t).Get(k);
                stack.Push(v);
                return LuaValue.TypeOf(v);
            }
            throw new Exception("");
        }

        public LuaValueEnum GetField(int idx, string k)
        {
            throw new NotImplementedException();
        }

        public LuaValueEnum GetI(int idx, long i)
        {
            throw new NotImplementedException();
        }

        public void SetTable(int idx)
        {
            Object t = stack.Get(idx);
            Object k = stack.Pop();
            Object v = stack.Pop();
            setTable(t, k, v);
        }

        public void SetField(int idx, string k)
        {
            Object t = stack.Get(idx);
            Object v = stack.Pop();
            setTable(t, k, v);
        }

        public void SetI(int idx, long i)
        {
            Object t = stack.Get(idx);
            Object v = stack.Pop();
            setTable(t, i, v);
        }

        void setTable(Object t, Object k, Object v)
        {
            if(TypeExtension.TypeEqual<LuaTable>(t))
            {
                ((LuaTable)t).Put(k, v);
                return;
            }
        }
        #endregion
    }
}
