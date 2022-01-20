using System.Collections.Generic;
using NSubstitute;

namespace Bloodeck.Tests.Utils
{
    public static class ListExtensions
    {
        public static TList WithIndexersOf<TList, T>(this TList self, IList<T> source)
            where TList : IList<T>
        {
            self[default].ReturnsForAnyArgs(callInfo =>
            {
                int index = callInfo.Arg<int>();
                return source[index];
            });
            return self;
        }

        public static TList WithListFeaturesOf<TList, T>(this TList self, IList<T> source)
            where TList : class, IList<T>
        {
            self
                .WithCollectionFeaturesOf(source)
                .WithIndexersOf(source);
            return self;
        }
    }
}