using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public class CardMBCollection : ICards
    {
        [SerializeField]
        private List<CardMB> _content = new List<CardMB>();

        public ICard this[int index]
        {
            get => _content[index];
            set => _content[index] = value as CardMB;
        }

        public int Count => _content.Count;

        public bool IsReadOnly => false;

        public ICollection<CardMB> AsMBs => _content;

        public IEnumerator<ICard> GetEnumerator()
        {
            return _content.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(ICard item)
        {
            _content.Add(item as CardMB);
        }

        public void Clear()
        {
            _content.Clear();
        }

        public bool Contains(ICard item)
        {
            return _content.ContainsParentItem(item);
        }

        public void CopyTo(ICard[] array, int arrayIndex)
        {
            _content.CopyTo((CardMB[]) array, arrayIndex);
        }

        public bool Remove(ICard item)
        {
            return _content.Remove(item as CardMB);
        }

        public int IndexOf(ICard item)
        {
            return _content.IndexOfParentItem(item);
        }

        public void Insert(int index, ICard item)
        {
            _content.InsertParentItem(index, item);
        }

        public void RemoveAt(int index)
        {
            _content.RemoveAt(index);
        }
    }
}