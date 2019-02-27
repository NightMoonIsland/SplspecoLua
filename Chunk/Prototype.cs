using System;
using System.Collections.Generic;
using System.Text;

namespace Chunk
{
    public class Prototype
    {
        public const int TAG_NIL        =   0x00;
        public const int TAG_BOOLEAN    =   0x01;
        public const int TAG_NUMBER     =   0x02;
        public const int TAG_INTEGER    =   0x13;
        public const int TAG_SHORT_STR  =   0x04;
        public const int TAG_LONG_STR   =   0x14;

        public string Source { get; private set; }
        public int LineDefined { get; private set; }
        public int LastLineDefined { get; private set; }
        public byte NumParams { get; private set; }
        public byte IsVararg { get; private set; }
        public byte MaxStackSize { get; private set; }
        public int[] Code { get; private set; }
        public Object[] Constants { get; private set; }
        public Upvalue[] Upvalues { get; private set; }
        public Prototype[] Protos { get; private set; }
        public int[] LineInfo { get; private set; }
        public LocVar[] LocVars { get; private set; }
        public string[] UpvalueNames { get; private set; }

        public void Read(BuffReader buffReader, string parentSource)
        {
            Source = buffReader.ReadLuaString();
            if(string.Empty == Source)
            {
                Source = parentSource;
            }
            LineDefined = buffReader.ReadInt32();
            LastLineDefined = buffReader.ReadInt32();
            NumParams = buffReader.ReadByte();
            IsVararg = buffReader.ReadByte();
            MaxStackSize = buffReader.ReadByte();

            readCode(buffReader);
            readConstants(buffReader);
            readUpvalues(buffReader);
            readProtos(buffReader, Source);
            readLineInfo(buffReader);
            readLocVars(buffReader);
            readUpvalueNames(buffReader);
        }

        void readCode(BuffReader buf)
        {
            Code = new int[buf.ReadInt32()];
            for(int i = 0; i < Code.Length; i++)
            {
                Code[i] = buf.ReadInt32();
            }
        }

        void readConstants(BuffReader buf)
        {
            Constants = new Object[buf.ReadInt32()];
            for(int i = 0; i < Constants.Length; i++)
            {
                Constants[i] = readConstant(buf);
            }
        }

        Object readConstant(BuffReader buf)
        {
            switch(buf.ReadByte())
            {
                case TAG_NIL:
                    return null;
                case TAG_BOOLEAN:
                    return buf.ReadByte() != 0;
                case TAG_INTEGER:
                    return buf.ReadInt64();
                case TAG_NUMBER:
                    return buf.ReadDouble();
                case TAG_SHORT_STR:
                    return buf.ReadLuaString();
                case TAG_LONG_STR:
                    return buf.ReadLuaString();
                default:
                    {

                    }
                    return null;
            }
        }

        void readUpvalues(BuffReader buf)
        {
            Upvalues = new Upvalue[buf.ReadInt32()];
            for(int i = 0; i < Upvalues.Length; i++)
            {
                Upvalues[i] = new Upvalue();
                Upvalues[i].Read(buf);
            }
        }

        void readProtos(BuffReader buf, string parentSource)
        {
            Protos = new Prototype[buf.ReadInt32()];
            for(int i = 0; i < Protos.Length; i++)
            {
                Protos[i] = new Prototype();
                Protos[i].Read(buf, parentSource);
            }
        }

        void readLineInfo(BuffReader buf)
        {
            LineInfo = new int[buf.ReadInt32()];
            for(int i = 0; i < LineInfo.Length; i++)
            {
                LineInfo[i] = buf.ReadInt32();
            }
        }

        void readLocVars(BuffReader buf)
        {
            LocVars = new LocVar[buf.ReadInt32()];
            for(int i = 0; i < LocVars.Length; i++)
            {
                LocVars[i] = new LocVar();
                LocVars[i].Read(buf);
            }
        }

        void readUpvalueNames(BuffReader buf)
        {
            UpvalueNames = new string[buf.ReadInt32()];
            for(int i = 0; i < UpvalueNames.Length; i++)
            {
                UpvalueNames[i] = buf.ReadLuaString();
            }
        }
    }
}
