using Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vm
{
    public struct OpCode
    {
        public delegate void Handler(int i, ILuaVM vm);

        public static readonly OpCode[] codes =
        {
            new OpCode(0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgN, OpModeEnum.iABC, InstructionsImplement.Move, ""),
            new OpCode(0, 1, OpArgMaskEnum.OpArgK, OpArgMaskEnum.OpArgN, OpModeEnum.iABx, InstructionsImplement.LoadK, ""),
            new OpCode(0, 1, OpArgMaskEnum.OpArgN, OpArgMaskEnum.OpArgN, OpModeEnum.iABx, InstructionsImplement.LoadKx, ""),
            new OpCode(0, 1, OpArgMaskEnum.OpArgU, OpArgMaskEnum.OpArgU, OpModeEnum.iABC, InstructionsImplement.Move, "")
        };


        public byte testFlag;
        public byte setAFlag;
        public OpArgMaskEnum argBMode;
        public OpArgMaskEnum argCMode;
        public OpModeEnum opMode;
        public Handler handler;
        public string name;

        public OpCode(byte testFlag,
            byte setAFlag,
            OpArgMaskEnum argBMode,
            OpArgMaskEnum argCMode,
            OpModeEnum opMode,
            Handler handler,
            string name)
        {
            this.testFlag = testFlag;
            this.setAFlag = setAFlag;
            this.argBMode = argBMode;
            this.argCMode = argCMode;
            this.handler = handler;
            this.opMode = opMode;
            this.name = name;
        }
    }
}
