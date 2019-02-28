using System;
using System.Collections.Generic;
using System.Text;

namespace Base
{
    public class TypeExtension
    {
        public static bool TypeEqual<T>(Object current)
        {
            if(current == null)
            {
                return false;
            }
            return current.GetType() == typeof(T);
        }
    }
}
