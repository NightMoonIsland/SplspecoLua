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
            new OpCode(OpCodeEnum.OP_MOVE, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgN, OpModeEnum.iABC, InstructionsImplement.Move, ""),
            new OpCode(OpCodeEnum.OP_LOADK, 0, 1, OpArgMaskEnum.OpArgK, OpArgMaskEnum.OpArgN, OpModeEnum.iABx, InstructionsImplement.LoadK, ""),
            new OpCode(OpCodeEnum.OP_LOADKX, 0, 1, OpArgMaskEnum.OpArgN, OpArgMaskEnum.OpArgN, OpModeEnum.iABx, InstructionsImplement.LoadKx, ""),
            new OpCode(OpCodeEnum.OP_LOADBOOL, 0, 1, OpArgMaskEnum.OpArgU, OpArgMaskEnum.OpArgU, OpModeEnum.iABC, InstructionsImplement.Move, ""),
            new OpCode(OpCodeEnum.OP_LOADNIL, 0, 1, OpArgMaskEnum.OpArgU, OpArgMaskEnum.OpArgN, OpModeEnum.iABC, InstructionsImplement.LoadNil, ""),
            new OpCode(OpCodeEnum.OP_GETUPVAL, 0, 1, OpArgMaskEnum.OpArgU, OpArgMaskEnum.OpArgN, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_GETTABUP, 0, 1, OpArgMaskEnum.OpArgU, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_GETTABLE, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_SETTABUP, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_SETUPVAL, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_SETTABLE, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_NEWTABLE, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_SELF, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_ADD, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_SUB, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_MUL, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_MOD, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_POW, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_DIV, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_IDIV, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_BAND, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_BOR, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_BXOR, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_SHL, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_SHR, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_UNM, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_BNOT, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_NOT, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_LEN, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgN, OpModeEnum.iABC, InstructionsImplement.Move, ""),
            new OpCode(OpCodeEnum.OP_CONCAT, 0, 1, OpArgMaskEnum.OpArgK, OpArgMaskEnum.OpArgN, OpModeEnum.iABx, InstructionsImplement.LoadK, ""),
            new OpCode(OpCodeEnum.OP_JMP, 0, 1, OpArgMaskEnum.OpArgN, OpArgMaskEnum.OpArgN, OpModeEnum.iABx, InstructionsImplement.LoadKx, ""),
            new OpCode(OpCodeEnum.OP_EQ, 0, 1, OpArgMaskEnum.OpArgU, OpArgMaskEnum.OpArgU, OpModeEnum.iABC, InstructionsImplement.Move, ""),
            new OpCode(OpCodeEnum.OP_LT, 0, 1, OpArgMaskEnum.OpArgU, OpArgMaskEnum.OpArgN, OpModeEnum.iABC, InstructionsImplement.LoadNil, ""),
            new OpCode(OpCodeEnum.OP_LE, 0, 1, OpArgMaskEnum.OpArgU, OpArgMaskEnum.OpArgN, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_TEST, 0, 1, OpArgMaskEnum.OpArgU, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_TESTSET, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_CALL, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_TAILCALL, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_RETURN, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_FORLOOP, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_FORPREP, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_TFORCALL, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_TFORLOOP, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_SETLIST, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_CLOSURE, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_VARARG, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
            new OpCode(OpCodeEnum.OP_EXTRAARG, 0, 1, OpArgMaskEnum.OpArgR, OpArgMaskEnum.OpArgK, OpModeEnum.iABC, null, ""),
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

        public OpCodeEnum type;
        public byte testFlag;
        public byte setAFlag;
        public OpArgMaskEnum argBMode;
        public OpArgMaskEnum argCMode;
        public OpModeEnum opMode;
        public OPAction action;
        public string name;

        public OpCode(
            OpCodeEnum type,
            byte testFlag,
            byte setAFlag,
            OpArgMaskEnum argBMode,
            OpArgMaskEnum argCMode,
            OpModeEnum opMode,
            OPAction action,
            string name)
        {
            this.type = type;
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
