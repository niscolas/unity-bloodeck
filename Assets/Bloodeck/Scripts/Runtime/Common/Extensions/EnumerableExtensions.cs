using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bloodeck
{
    public static class EnumerableExtensions
    {
        public static bool CheckIsEmpty<T>(this IEnumerable<T> self)
        {
            return !self.Any();
        }
    }
}