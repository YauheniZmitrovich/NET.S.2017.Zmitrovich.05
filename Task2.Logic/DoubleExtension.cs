using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Logic
{

    /// <summary>
    /// The class helps to "add" methods of converting to existing double type 
    /// without creating a new derived type, recompiling, or otherwise modifying the original type.
    /// </summary>
    public static class DoubleExtension
    {

        /// <summary>
        /// Converts your double number to IEE 754. 
        /// </summary>
        /// <returns>
        /// String with binary representation of a double number by IEE 754.
        /// </returns>
        /// <param name="d">
        /// The implicit double parameter.
        /// </param>
        public static string ConvertToIEE754(this double d)
        {

            if (d == double.Epsilon)
                return "0001";

            if (d == 0.0)
                return "0000";


            byte[] bArr = BitConverter.GetBytes(d);
            Array.Reverse(bArr);

            string s = "";
            foreach (byte b in bArr)
                s += Convert.ToString(b, 2).PadLeft(8, '0');


            return s;
        }

    }
}
