using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public class ParentCollection<TBase, TChild> : ICollection<TBase>
        where TChild : TBase
    {
        [SerializeField]
        protected List<TChild> _content = new List<TChild>();

        public int Count => _content.Count;

        public bool IsReadOnly => false;
        
        public IEnumerable<TChild> AsChildClass => _content;

        public ParentCollection() { }

        public ParentCollection(IEnumerable<TChild> content)
        {
            _content = content.ToList();
        }

        public ParentCollection(params TChild[] content)
        {
            _content = content.ToList();
        }

        public IEnumerator<TBase> GetEnumerator()
        {
            return ((IEnumerable<TBase>) _content).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(TBase item)
        {
            _content.AddParentItem(item);
        }

        public void Clear()
        {
            _content.Clear();
        }

        public bool Contains(TBase item)
        {
            return _content.ContainsParentItem(item);
        }

        public void CopyTo(TBase[] array, int arrayIndex)
        {
            _content.CopyToParentArray(array, arrayIndex);
        }

        public bool Remove(TBase item)
        {
            return _content.RemoveParentItem(item);
        }
    }
}