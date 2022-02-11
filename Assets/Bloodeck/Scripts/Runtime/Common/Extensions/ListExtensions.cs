using System.Collections.Generic;

namespace Bloodeck
{
    public static class ListExtensions
    {
        public static bool CheckIsEmpty<T>(this IList<T> self)
        {
            return self.Count == 0;
        }
    }
}