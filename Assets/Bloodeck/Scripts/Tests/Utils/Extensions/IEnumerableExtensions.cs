using System.Collections.Generic;
using System.Linq;
using NSubstitute;

namespace Bloodeck.Tests.Utils
{
    public static class IEnumerableExtensions
    {
        public static TSelf WithGetEnumeratorReturning<T, TSelf>(
            this TSelf self, IEnumerable<T> content)
            where TSelf : IEnumerable<T>
        {
            self.GetEnumerator().Returns(_ => content.GetEnumerator());
            return self;
        }

        public static TSelf WithContainsReturning<T, TSelf>(
            this TSelf self, IEnumerable<T> content)
            where TSelf : IEnumerable<T>
        {
            self.Contains(default).ReturnsForAnyArgs(callInfo => content.Contains(callInfo.Arg<T>()));
            return self;
        }
    }
}