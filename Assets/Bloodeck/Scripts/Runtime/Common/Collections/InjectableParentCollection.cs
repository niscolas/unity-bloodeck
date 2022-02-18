using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [Serializable]
    public class InjectableParentCollection<TBase, TChild> : ICollection<TBase>
        where TChild : TBase
    {
        [Inject, SerializeField]
        protected List<TChild> _content = new List<TChild>();

        public int Count => _content.Count;
        public bool IsReadOnly => false;

        public InjectableParentCollection() { }

        public InjectableParentCollection(IEnumerable<TChild> content)
        {
            _content = content.ToList();
        }

        public InjectableParentCollection(params TChild[] content)
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