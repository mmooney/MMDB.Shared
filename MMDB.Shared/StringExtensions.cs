using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMDB.Shared
{
    public static class StringExtensions
    {
        public static bool Contains(this string x, string value, StringComparison comparer)
        {
            return (x.IndexOf(value, comparer) > -1);
        }
    }
}
