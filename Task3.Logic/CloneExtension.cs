using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Logic
{
    public static class CloneExtension
    {
        public static T Clone<T>(this T o) where T : ICloneable
        {
            return (T)o.Clone();
        }
    }
}
