using System;
using System.Collections;
using System.Collections.Generic;
using niscolas.UnityUtils.Core.Extensions;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public struct SerializableCardHand : ICardHand
    {
        [SerializeField]
        private CardMBCollection _cards;

        [SerializeField]
        private IntReference _maxCardCount;

        public int Count => _cards.Count;

        public bool IsReadOnly => false;

        public int MaxCardCount
        {
            get => _maxCardCount.Value;
            set => _maxCardCount.Value = value;
        }

        public ICard this[int index]
        {
            get => _cards[index];
            set => _cards[index] = value as CardMB;
        }

        public IEnumerator<ICard> GetEnumerator()
        {
            return _cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(ICard item)
        {
            if (CheckIsFull())
            {
                return;
            }

            _cards.AddParentItem(item);
        }

        public void Clear()
        {
            _cards.Clear();
        }

        public bool Contains(ICard item)
        {
            return _cards.ContainsParentItem(item);
        }

        public void CopyTo(ICard[] array, int arrayIndex)
        {
            _cards.CopyToParentArray(array, arrayIndex);
        }

        public bool Remove(ICard item)
        {
            return _cards.RemoveParentItem(item);
        }

        public int IndexOf(ICard item)
        {
            return _cards.IndexOfParentItem(item);
        }

        public void Insert(int index, ICard item)
        {
            if (CheckIsFull())
            {
                return;
            }

            _cards.InsertParentItem(index, item);
        }

        public void RemoveAt(int index)
        {
            _cards.RemoveAt(index);
        }

        private bool CheckIsFull()
        {
            return Count == MaxCardCount;
        }
    }
}