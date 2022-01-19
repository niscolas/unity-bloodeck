using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public struct SerializableEntityComponentTemplates : IEntityComponentTemplates
    {
        [SerializeReference, SubclassSelector]
        private List<IEntityComponentTemplate> _content;

        public int Count => _content.Count;

        public bool IsReadOnly => false;

        public bool TryGet<T>(out T value) where T : IEntityComponentTemplate
        {
            return _content.TryGetFirstOfType(out value);
        }

        public IEnumerator<IEntityComponentTemplate> GetEnumerator()
        {
            return _content.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(IEntityComponentTemplate item)
        {
            _content.AddParentItem(item);
        }

        public void Clear()
        {
            _content.Clear();
        }

        public bool Contains(IEntityComponentTemplate item)
        {
            return _content.ContainsParentItem(item);
        }

        public void CopyTo(IEntityComponentTemplate[] array, int arrayIndex)
        {
            _content.CopyToParentArray(array, arrayIndex);
        }

        public bool Remove(IEntityComponentTemplate item)
        {
            return _content.RemoveParentItem(item);
        }
    }
}