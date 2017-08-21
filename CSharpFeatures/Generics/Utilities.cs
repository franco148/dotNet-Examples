using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    class Utilities
    {
        public T Max<T>(T a, T b) where T : IComparable
        {
            return a.CompareTo(b)>0 ? a : b;
        }
    }
}
