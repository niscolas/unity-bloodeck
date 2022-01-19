using System;
using System.Collections.Generic;
using System.Linq;
using niscolas.UnityUtils.Core.Extensions;

namespace Bloodeck
{
    public static class IEnumerableExtensions
    {
        public static bool TryGetFirstOfType<T1, T2>(this IEnumerable<T1> self, out T2 result)
        {
            result = self.FirstOfType<T1, T2>();
            return !result.IsUnityNull();
        }

        public static T2 FirstOfType<T1, T2>(this IEnumerable<T1> self)
        {
            T2 result = default;
            self.ForEach(x =>
            {
                if (x is T2 t2)
                {
                    result = t2;
                }
            });
            return result;
        }

        public static IEnumerable<TOutput> Map<TInput, TOutput>(
            this IEnumerable<TInput> self,
            Func<TInput, TOutput> func)
        {
            foreach (TInput input in self)
            {
                yield return func(input);
            }
        }
    }
}