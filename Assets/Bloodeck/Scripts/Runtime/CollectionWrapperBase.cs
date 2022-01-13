using System.Collections;
using System.Collections.Generic;

namespace Bloodeck
{
    public abstract class CollectionWrapperBase<T> : ICollection<T>
    {
        public int Count => Content.Count;

        public bool IsReadOnly => Content.IsReadOnly;

        protected abstract ICollection<T> Content { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            return Content.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            Content.Add(item);
        }

        public void Clear()
        {
            Content.Clear();
        }

        public bool Contains(T item)
        {
            return Content.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Content.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return Content.Remove(item);
        }
    }
}