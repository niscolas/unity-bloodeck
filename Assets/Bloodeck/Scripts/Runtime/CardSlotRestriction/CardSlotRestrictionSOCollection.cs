using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public class CardSlotRestrictionSOCollection : ICardSlotRestrictions
    {
        [SerializeField]
        private List<CardSlotRestrictionSO> _content = new List<CardSlotRestrictionSO>();

        public int Count => _content.Count;

        public bool IsReadOnly => false;

        public bool Validate(ICard card)
        {
            return _content.All(x => x.Validate(card));
        }

        public IEnumerator<ICardSlotRestriction> GetEnumerator()
        {
            return _content.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(ICardSlotRestriction item)
        {
            _content.AddParentItem(item);
        }

        public void Clear()
        {
            _content.Clear();
        }

        public bool Contains(ICardSlotRestriction item)
        {
            return _content.ContainsParentItem(item);
        }

        public void CopyTo(ICardSlotRestriction[] array, int arrayIndex)
        {
            _content.CopyToParentArray(array, arrayIndex);
        }

        public bool Remove(ICardSlotRestriction item)
        {
            return _content.RemoveParentItem(item);
        }
    }
}