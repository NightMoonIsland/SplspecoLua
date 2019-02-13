using System;
using System.Collections.Generic;
using System.Text;

namespace Vm
{
    public struct OpCode
    {
        public static readonly OpCode[] codes =
        {
            new OpCode(0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgN, OpModeEnum.iABC, "" ),
            new OpCode(0, 1, OpArgMaskEnum.OpArgK, OpArgMaskEnum.OpArgN, OpModeEnum.iABx, ""),
            new OpCode(0, 1, OpArgMaskEnum.OpArgN, OpArgMaskEnum.OpArgN, OpModeEnum.iABx, ""),
        };


        public byte testFlag;
        public byte setAFlag;
        public OpArgMaskEnum argBMode;
        public OpArgMaskEnum argCMode;
        public OpModeEnum opMode;
        public string name;

        public OpCode(byte testFlag,
            byte setAFlag,
            OpArgMaskEnum argBMode,
            OpArgMaskEnum argCMode,
            OpModeEnum opMode,
            string name)
        {
            this.testFlag = testFlag;
            this.setAFlag = setAFlag;
            this.argBMode = argBMode;
            this.argCMode = argCMode;
            this.opMode = opMode;
            this.name = name;
        }
    }
}
