using System;
using System.Collections.Generic;
using System.Text;

namespace Number
{
    public class LuaNumber
    {
        public static bool IsInteger(double? f)
        {
            if(f == null)
            {
                return false;
            }
            return f == (long)f;
        }

        public static long? ParseLong(string str)
        {
            try
            {
                return Convert.ToInt64(str);
            }
            catch(SystemException e)
            {
                throw e;
            }
        }
        public static long? ParseLong(double? f)
        {
            try
            {
                return Convert.ToInt64(f);
            }
            catch(SystemException e)
            {
                throw e;
            }
        }

        public static double? ParseDouble(string str)
        {
            try
            {
                return Convert.ToDouble(str);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
