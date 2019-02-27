using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    public enum OpArgMaskEnum
    {
        /// <summary>
        /// 不表示任何信息 不会被使用
        /// </summary>
        OpArgN,

        /// <summary>
        /// 布尔值 整数值 upvalue索引 子函数索引
        /// </summary>
        OpArgU,

        /// <summary>
        /// iABC模式下 表示寄存器索引
        /// iAsBx模式下 表示跳转偏移
        /// </summary>
        OpArgR,

        /// <summary>
        /// 常量表索引 
        /// 寄存器索引
        /// </summary>
        OpArgK,
    }
}
