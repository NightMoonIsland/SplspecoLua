using Chunk;
using System;
using System.IO;
using Vm;
using Api;

namespace TestOp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string path = Path.GetFullPath(args[0]);
                Console.WriteLine($"path {path}");
                byte[] data = File.ReadAllBytes(Path.GetFullPath(args[0]));
                Prototype proto = BinaryChunk.Undump(data);
                Console.WriteLine($"byte {data.Length}");
                list(proto);
            }
            Console.WriteLine("Hello World!");
        }

        private static void list(Prototype f)
        {
            printHeader(f);
            printCode(f);
            printDetail(f);
            foreach(var p in f.Protos)
            {
                list(p);
            }
        }

        private static void printHeader(Prototype f)
        {
            string funcType = f.LineDefined > 0 ? "function" : "main";
            string varargFlag = f.IsVararg > 0 ? "+" : "";

            Console.WriteLine
                (string.Format("\n{0} <{1}:{2},{3}> ({4} instructions)\n", funcType, f.Source, f.LineDefined, f.LastLineDefined, f.Code.Length));
            Console.WriteLine(
                string.Format("{0}{1} params, {2} slots, {3} upvalues,", f.NumParams, varargFlag, f.MaxStackSize, f.Upvalues.Length));
            Console.WriteLine(
                string.Format("{0} locals, {1} contants, {2} functions", f.LocVars.Length, f.Constants.Length, f.Protos.Length));
        }

        private static void printCode(Prototype f)
        {
            int[] code = f.Code;
            int[] lineInfo = f.LineInfo;
            for (int i = 0; i < code.Length; i++)
            {
                string line = lineInfo.Length > 0 ? "" + lineInfo[i] : "-";
                Console.WriteLine(string.Format("\t{0}\t[{1}]\t{2} \t", i + 1, line, Instruction.GetOpCode(code[i]).ToString()));
                printOperands(code[i]);
            }
        }

        private static void printOperands(int i)
        {
            OpCode opCode = Instruction.GetOpCode(i);
            int a = Instruction.GetA(i);
            Console.Write(opCode.OpMode.ToString() + " ");
            switch(opCode.OpMode)
            {
                case OpModeEnum.iABC:
                    {
                        Console.Write(string.Format(" {0}", a));
                        if (opCode.ArgBMode != OpArgMaskEnum.OpArgN)
                        {
                            int b = Instruction.GetB(i);
                            Console.Write(string.Format(" {0}", b > 0xFF ? -1 - (b & 0xFF) : b));
                        }
                        if(opCode.ArgCMode != OpArgMaskEnum.OpArgN)
                        {
                            int c = Instruction.GetC(i);
                            Console.Write(string.Format(" {0}", c > 0xFF ? -1 - (c & 0xFF) : c));
                        }
                        break;
                    }
                case OpModeEnum.iABx:
                    {
                        Console.Write(string.Format(" {0}", a));
                        int bx = Instruction.GetBx(i);
                        if(opCode.ArgBMode == OpArgMaskEnum.OpArgK)
                        {
                            Console.Write(string.Format(" {0}", -1 - bx));
                        }
                        else if(opCode.ArgBMode == OpArgMaskEnum.OpArgU)
                        {
                            Console.Write(string.Format(" {0}", -1 - bx));
                        }
                        break;
                    }
                case OpModeEnum.iAsBx:
                    {
                        int sbx = Instruction.GetSBx(i);
                        Console.Write(string.Format("{0} {1}", a, sbx));
                        break;
                    }
                case OpModeEnum.iAx:
                    {
                        int ax = Instruction.GetAx(i);
                        Console.Write(string.Format(" {0}", -1 - ax));
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            Console.WriteLine("");
        }

        private static void printDetail(Prototype f)
        {
            Console.WriteLine(string.Format("constants ({0}):\n", f.Constants.Length));
            int i = 1;
            foreach(Object k in f.Constants)
            {
                Console.WriteLine("\t{0}\t{1}\n", i++, constantToString(k));
            }

            i = 0;
            Console.WriteLine(string.Format("locals ({0}):\n", f.LocVars.Length));
            foreach(LocVar locVar in f.LocVars)
            {
                Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\n", 
                    i++, locVar.VarName, locVar.StartPc + 1, locVar.EndPc + 1);
            }
        }

        private static string constantToString(Object k)
        {
            return "";
        }
    }
}
