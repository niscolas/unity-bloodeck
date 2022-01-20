using System.Collections.Generic;
using NSubstitute;

namespace Bloodeck.Tests.Utils
{
    public static class CollectionExtensions
    {
        public static TCollection WithAddOf<TCollection, T>(this TCollection self, ICollection<T> source)
            where TCollection : class, ICollection<T>
        {
            self
                .When(x => x.Add(Arg.Any<T>()))
                .Do(callInfo =>
                {
                    source.Add(callInfo.Arg<T>());
                });
            return self;
        }

        public static TCollection WithClearOf<TCollection, T>(this TCollection self, ICollection<T> source)
            where TCollection : class, ICollection<T>
        {
            self
                .When(x => x.Clear())
                .Do(_ => source.Clear());
            return self;
        }

        public static TCollection WithCollectionFeaturesOf<TCollection, T>(this TCollection self, ICollection<T> source)
            where TCollection : class, ICollection<T>
        {
            self
                .WithGetEnumeratorOf(source)
                .WithAddOf(source)
                .WithClearOf(source)
                .WithCountOf(source)
                .WithRemoveOf(source);
            return self;
        }

        public static TCollection WithCountOf<TCollection, T>(this TCollection self, ICollection<T> source)
            where TCollection : ICollection<T>
        {
            self.Count.Returns(_ => source.Count);
            return self;
        }

        public static TCollection WithRemoveOf<TCollection, T>(this TCollection self, ICollection<T> source)
            where TCollection : ICollection<T>
        {
            self
                .Remove(default)
                .ReturnsForAnyArgs(callInfo => source.Remove(callInfo.Arg<T>()));
            return self;
        }
    }
}