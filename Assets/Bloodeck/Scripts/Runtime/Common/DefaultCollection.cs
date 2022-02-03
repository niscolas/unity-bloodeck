using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public class DefaultCollection<T> : ICollection<T>
    {
        [SerializeField]
        private List<T> _content = new List<T>();

        public int Count => _content.Count;

        public bool IsReadOnly => false;

        public DefaultCollection() { }

        public DefaultCollection(IEnumerable<T> content)
        {
            _content = content.ToList();
        }

        public DefaultCollection(params T[] content)
        {
            _content = content.ToList();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _content.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            _content.Add(item);
        }

        public void Clear()
        {
            _content.Clear();
        }

        public bool Contains(T item)
        {
            return _content.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _content.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _content.Remove(item);
        }
    }
}