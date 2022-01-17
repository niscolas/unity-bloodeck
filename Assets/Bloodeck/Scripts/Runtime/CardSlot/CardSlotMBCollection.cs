using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public class CardSlotMBCollection : ICardSlots
    {
        [SerializeField]
        private List<CardSlotMB> _content = new List<CardSlotMB>();

        public int Count => _content.Count;

        public bool IsReadOnly => false;

        public CardSlotMBCollection() { }

        public CardSlotMBCollection(IEnumerable<CardSlotMB> content)
        {
            _content = content.ToList();
        }

        public IEnumerator<ICardSlot> GetEnumerator()
        {
            return _content.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(ICardSlot item)
        {
            _content.AddParentItem(item);
        }

        public void Clear()
        {
            _content.Clear();
        }

        public bool Contains(ICardSlot item)
        {
            return _content.ContainsParentItem(item);
        }

        public void CopyTo(ICardSlot[] array, int arrayIndex)
        {
            _content.CopyToParentArray(array, arrayIndex);
        }

        public bool Remove(ICardSlot item)
        {
            return _content.RemoveParentItem(item);
        }
    }
}