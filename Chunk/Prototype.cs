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

        string source;
        int lineDefined;
        int lastLineDefined;
        byte numParams;
        byte isVararg;
        byte maxStackSize;
        int[] code;
        Object[] constants;
        Upvalue[] upvalues;
        Prototype[] protos;
        int[] lineInfo;
        LocVar[] locVars;
        string[] upvalueNames;

        public void Read(BuffReader buffReader, string parentSource)
        {
            source = buffReader.ReadLuaString();
            if(string.Empty == source)
            {
                source = parentSource;
            }
            lineDefined = buffReader.ReadInt32();
            lastLineDefined = buffReader.ReadInt32();
            numParams = buffReader.ReadByte();
            isVararg = buffReader.ReadByte();
            maxStackSize = buffReader.ReadByte();

            readCode(buffReader);
            readConstants(buffReader);
            readUpvalues(buffReader);
            readProtos(buffReader, source);
            readLineInfo(buffReader);
            readLocVars(buffReader);
            readUpvalueNames(buffReader);
        }

        void readCode(BuffReader buf)
        {
            code = new int[buf.ReadInt32()];
            for(int i = 0; i < code.Length; i++)
            {
                code[i] = buf.ReadInt32();
            }
        }

        void readConstants(BuffReader buf)
        {
            constants = new Object[buf.ReadInt32()];
            for(int i = 0; i < constants.Length; i++)
            {
                constants[i] = readConstant(buf);
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
            upvalues = new Upvalue[buf.ReadInt32()];
            for(int i = 0; i < upvalues.Length; i++)
            {
                upvalues[i] = new Upvalue();
                upvalues[i].Read(buf);
            }
        }

        void readProtos(BuffReader buf, string parentSource)
        {
            protos = new Prototype[buf.ReadInt32()];
            for(int i = 0; i < protos.Length; i++)
            {
                protos[i] = new Prototype();
                protos[i].Read(buf, parentSource);
            }
        }

        void readLineInfo(BuffReader buf)
        {
            lineInfo = new int[buf.ReadInt32()];
            for(int i = 0; i < lineInfo.Length; i++)
            {
                lineInfo[i] = buf.ReadInt32();
            }
        }

        void readLocVars(BuffReader buf)
        {
            locVars = new LocVar[buf.ReadInt32()];
            for(int i = 0; i < locVars.Length; i++)
            {
                locVars[i] = new LocVar();
                locVars[i].Read(buf);
            }
        }

        void readUpvalueNames(BuffReader buf)
        {
            upvalueNames = new string[buf.ReadInt32()];
            for(int i = 0; i < upvalueNames.Length; i++)
            {
                upvalueNames[i] = buf.ReadLuaString();
            }
        }
    }
}
