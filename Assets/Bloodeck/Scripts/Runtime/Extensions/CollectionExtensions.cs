using System.Collections.Generic;

namespace Bloodeck
{
    public static class CollectionExtensions
    {
        public static void AddParentItem<T, TBase>(
            this ICollection<T> collection, TBase item) where T : TBase
        {
            if (item is T downCastedItem)
            {
                collection.Add(downCastedItem);
            }
        }

        public static bool ContainsParentItem<T, TBase>(
            this ICollection<T> collection, TBase item) where T : TBase
        {
            if (item is T downCastedItem)
            {
                return collection.Contains(downCastedItem);
            }
            else
            {
                return false;
            }
        }

        public static void CopyToParentArray<T, TBase>(
            this ICollection<T> collection, TBase[] array, int arrayIndex)
            where T : TBase
        {
            if (array is T[] downCastedArray)
            {
                collection.CopyTo(downCastedArray, arrayIndex);
            }
        }

        public static bool RemoveParentItem<T, TBase>(
            this ICollection<T> collection, TBase item) where T : TBase
        {
            if (item is T downCastedItem)
            {
                return collection.Remove(downCastedItem);
            }
            else
            {
                return false;
            }
        }
    }
}