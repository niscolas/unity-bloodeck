using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public class CardTemplateSOCollection : ICardTemplates
    {
        [SerializeField]
        private List<CardTemplateSO> _content;

        public int Count => _content.Count;

        public bool IsReadOnly => false;

        public IEnumerator<ICardTemplate> GetEnumerator()
        {
            return _content.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(ICardTemplate item)
        {
            _content.AddParentItem(item);
        }

        public void Clear()
        {
            _content.Clear();
        }

        public bool Contains(ICardTemplate item)
        {
            return _content.ContainsParentItem(item);
        }

        public void CopyTo(ICardTemplate[] array, int arrayIndex)
        {
            _content.CopyToParentArray(array, arrayIndex);
        }

        public bool Remove(ICardTemplate item)
        {
            return _content.RemoveParentItem(item);
        }
    }
}