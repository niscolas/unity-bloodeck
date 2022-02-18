using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public class WatchableParentList<TBase, TChild> : IList<TBase>, IWatchableCollection<TBase>
        where TChild : TBase
    {
        [SerializeField]
        protected List<TChild> _content = new List<TChild>();

        public event Action<TBase> Added;
        public event Action<TBase> Removed;
        public event Action Changed;
        public event Action Cleared;

        public int Count => _content.Count;

        public bool IsReadOnly => false;

        public TBase this[int index]
        {
            get => _content[index];
            set => _content[index] = (TChild) value;
        }

        public WatchableParentList() { }

        public WatchableParentList(IEnumerable<TChild> content)
        {
            _content = content.ToList();
        }

        public WatchableParentList(params TChild[] content)
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
            OnAdded(item);
        }

        public void Clear()
        {
            _content.Clear();
            OnCleared();
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
            bool result = _content.RemoveParentItem(item);
            OnRemoved(item);
            return result;
        }

        public int IndexOf(TBase item)
        {
            return _content.IndexOfParentItem(item);
        }

        public void Insert(int index, TBase item)
        {
            _content.InsertParentItem(index, item);
            OnAdded(item);
        }

        public void RemoveAt(int index)
        {
            TBase item = _content[index];
            Remove(item);
            OnRemoved(item);
        }

        private void OnAdded(TBase item)
        {
            Added?.Invoke(item);
            OnChanged();
        }

        private void OnRemoved(TBase item)
        {
            Removed?.Invoke(item);
            OnChanged();
        }

        private void OnCleared()
        {
            Cleared?.Invoke();
            OnChanged();
        }

        private void OnChanged()
        {
            Changed?.Invoke();
        }
    }
}