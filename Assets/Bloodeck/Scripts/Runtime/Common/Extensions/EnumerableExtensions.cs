using System;
using System.Collections.Generic;
using System.Linq;
using niscolas.UnityUtils.Core.Extensions;

namespace Bloodeck
{
    public static class EnumerableExtensions
    {
        public static bool CheckIsEmpty<T>(this IEnumerable<T> self)
        {
            return !self.Any();
        }

        public static T FirstOfType<T>(this IEnumerable<T> self, Type type)
        {
            T result = default;
            foreach (T element in self)
            {
                if (element.GetType().IsSameOfSubclassOf(type))
                {
                    result = element;
                }
            }

            return result;
        }

        public static bool TryGetFirstOfType<T>(this IEnumerable<T> self, Type type, out T result)
        {
            result = self.FirstOfType(type);
            return !result.IsUnityNull();
        }
    }
}