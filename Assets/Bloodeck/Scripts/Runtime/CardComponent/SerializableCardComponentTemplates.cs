using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public struct SerializableCardComponentTemplates : ICardComponentTemplates
    {
        [SerializeReference, SubclassSelector]
        private List<ICardComponentTemplate> _content;

        public int Count => _content.Count;

        public bool IsReadOnly => false;

        public bool TryGet<T>(out T value) where T : ICardComponentTemplate
        {
            return _content.TryGetFirstOfType(out value);
        }

        public IEnumerator<ICardComponentTemplate> GetEnumerator()
        {
            return _content.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(ICardComponentTemplate item)
        {
            _content.AddParentItem(item);
        }

        public void Clear()
        {
            _content.Clear();
        }

        public bool Contains(ICardComponentTemplate item)
        {
            return _content.ContainsParentItem(item);
        }

        public void CopyTo(ICardComponentTemplate[] array, int arrayIndex)
        {
            _content.CopyToParentArray(array, arrayIndex);
        }

        public bool Remove(ICardComponentTemplate item)
        {
            return _content.RemoveParentItem(item);
        }
    }
}