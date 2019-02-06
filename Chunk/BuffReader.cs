using System;
using System.Collections.Generic;
using System.Text;

namespace Chunk
{
    public class BuffReader
    {
        List<byte> datas;
        public BuffReader(byte[] data)
        {
            datas = new List<byte>(data);
        }

        public byte ReadByte()
        {
            byte b = this.datas[0];
            Console.WriteLine($"byte {b}");
            datas.RemoveRange(0, 1);
            return b;
        }

        public byte[] ReadBytes(int n)
        {
            byte[] bytes = datas.GetRange(0, n).ToArray();
            datas.RemoveRange(0, n);
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine($"byte {i}: {bytes[i]}");
            }
            return bytes;
        }

        public uint ReadUint32()
        {
            byte[] bytes = datas.GetRange(0, 4).ToArray();
            //if (BitConverter.IsLittleEndian)
            //{
            //    Array.Reverse(bytes);
            //}
            uint ret = System.BitConverter.ToUInt32(bytes, 0);
            datas.RemoveRange(0, 4);
            return ret;
        }

        public int ReadInt32()
        {
            byte[] bytes = datas.GetRange(0, 4).ToArray();
            //if (BitConverter.IsLittleEndian)
            //{
            //    Array.Reverse(bytes);
            //}
            int ret = System.BitConverter.ToInt32(bytes, 0);
            datas.RemoveRange(0, 4);
            return ret;
        }

        public ulong ReadUint64()
        {
            byte[] bytes = datas.GetRange(0, 8).ToArray();
            //if (BitConverter.IsLittleEndian)
            //{
            //    Array.Reverse(bytes);
            //}
            ulong ret = System.BitConverter.ToUInt64(bytes, 0);
            datas.RemoveRange(0, 8);
            return ret;
        }

        public long ReadInt64()
        {
            byte[] bytes = datas.GetRange(0, 8).ToArray();
            //if (BitConverter.IsLittleEndian)
            //{
            //    Array.Reverse(bytes);
            //}
            long ret = System.BitConverter.ToInt64(bytes, 0);
            datas.RemoveRange(0, 8);
            return ret;
        }

        public double ReadDouble()
        {
            byte[] bytes = datas.GetRange(0, 8).ToArray();
            //if (BitConverter.IsLittleEndian)
            //{
            //    Array.Reverse(bytes);
            //}
            double ret = System.BitConverter.ToDouble(bytes, 0);
            datas.RemoveRange(0, 8);
            return ret;
        }

        public string ReadString()
        {
            int size = (int)ReadByte();
            if(size == 0)
            {
                return "";
            }
            if(size == 0xFF)
            {
                size = (int)ReadUint64();
            }
            byte[] bytes = datas.GetRange(0, size).ToArray();
            string str = System.Text.Encoding.ASCII.GetString(bytes);
            datas.RemoveRange(0, size);
            return str;
        }

        public string ReadLuaString()
        {
            int size = ReadByte() & 0xFF;
            if(size == 0)
            {
                return "";
            }
            if(size == 0xFF)
            {
                size = (int)ReadUint64();
            }
            byte[] a = ReadBytes(size - 1);
            return System.Text.Encoding.ASCII.GetString(a);
        }
    }
}
