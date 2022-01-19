using System.Collections.Generic;
using NSubstitute;

namespace Bloodeck.Tests.Utils
{
    public static class ListExtensions
    {
        public static TList WithIndexersOf<TList, T>(this TList self, IList<T> source)
            where TList : IList<T>
        {
            source.ForEach((x, i) => self[i].Returns(x));
            return self;
        }

        public static TList WithCountOf<TList, T>(this TList self, IList<T> source)
            where TList : IList<T>
        {
            self.Count.Returns(source.Count);
            return self;
        }

        public static TList WithBasicListFeaturesOf<TList, T>(this TList self, IList<T> source)
            where TList : IList<T>
        {
            self.WithGetEnumeratorReturning(source);
            self.WithCountOf(source);
            source.ForEach((x, i) => self[i].Returns(x));
            return self;
        }
    }
}