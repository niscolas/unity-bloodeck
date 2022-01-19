using System;
using System.Collections.Generic;

namespace Bloodeck
{
    public static class ListExtensions
    {
        public static void Shuffle<T>(this IList<T> self)
        {
            int GetRandomIndex(int i)
            {
                return UnityEngine.Random.Range(0, i + 1);
            }

            self.Shuffle(GetRandomIndex);
        }

        public static void Shuffle<T>(this IList<T> self, Random random)
        {
            int GetRandomIndex(int i)
            {
                return random.Next(0, i + 1);
            }

            self.Shuffle(GetRandomIndex);
        }

        public static void Shuffle<T>(this IList<T> self, Func<int, int> randomIndexFunc)
        {
            for (int i = self.Count - 1; i > 0; i--)
            {
                int randomIndex = randomIndexFunc(i);

                (self[i], self[randomIndex]) = (self[randomIndex], self[i]);
            }
        }

        public static void InsertParentItem<TParent, TChild>(this IList<TChild> self, int index, TParent item)
        {
            if (item is TChild downCastedItem)
            {
                self.Insert(index, downCastedItem);
            }
        }
        
        public static int IndexOfParentItem<TParent, TChild>(this IList<TChild> self, TParent item)
        {
            if (item is TChild downCastedItem)
            {
                return self.IndexOf(downCastedItem);
            }
            else
            {
                return -1;
            }
        }

        public static void ForEach<T>(this IList<T> self, Action<T, int> action)
        {
            for (int i = 0; i < self.Count; i++)
            {
                action(self[i], i);
            }
        }
    }
}