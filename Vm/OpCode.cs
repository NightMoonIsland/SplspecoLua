using Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vm
{
    public class OpCode
    {
        public delegate void OPAction(int i, ILuaVM vm);

        public static readonly OpCode[] codes =
        {
            new OpCode(0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgN, OpModeEnum.iABC, InstructionsImplement.Move, ""),
            new OpCode(0, 1, OpArgMaskEnum.OpArgK, OpArgMaskEnum.OpArgN, OpModeEnum.iABx, InstructionsImplement.LoadK, ""),
            new OpCode(0, 1, OpArgMaskEnum.OpArgN, OpArgMaskEnum.OpArgN, OpModeEnum.iABx, InstructionsImplement.LoadKx, ""),
            new OpCode(0, 1, OpArgMaskEnum.OpArgU, OpArgMaskEnum.OpArgU, OpModeEnum.iABC, InstructionsImplement.Move, "")
        };

        public bool NotEqual(OpCodeEnum op)
        {
            int idx = (int)op;
            if(op < 0 || idx >= codes.Length)
            {
                return false;
            }
            else
            {
                return this == codes[idx];
            }
        }

        public byte testFlag;
        public byte setAFlag;
        public OpArgMaskEnum argBMode;
        public OpArgMaskEnum argCMode;
        public OpModeEnum opMode;
        public OPAction action;
        public string name;

        public OpCode(byte testFlag,
            byte setAFlag,
            OpArgMaskEnum argBMode,
            OpArgMaskEnum argCMode,
            OpModeEnum opMode,
            OPAction action,
            string name)
        {
            this.testFlag = testFlag;
            this.setAFlag = setAFlag;
            this.argBMode = argBMode;
            this.argCMode = argCMode;
            this.action = action;
            this.opMode = opMode;
            this.name = name;
        }


    }
}
