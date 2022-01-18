using System.Collections;
using System.Collections.Generic;
using niscolas.UnityUtils.Core;
using UnityEngine;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Entity Components")]
    public class EntityComponentsMB : CachedMB, IEntityComponents
    {
        [SerializeField]
        private List<EntityComponentMB> _content = new List<EntityComponentMB>();

        public int Count => _content.Count;

        public bool IsReadOnly => false;

        public bool TryGet<T>(out T value) where T : IEntityComponent
        {
            return _content.TryGetFirstOfType(out value);
        }

        public IEnumerator<IEntityComponent> GetEnumerator()
        {
            return _content.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(IEntityComponent item)
        {
            _content.AddParentItem(item);
        }

        public void Clear()
        {
            _content.Clear();
        }

        public bool Contains(IEntityComponent item)
        {
            return _content.ContainsParentItem(item);
        }

        public void CopyTo(IEntityComponent[] array, int arrayIndex)
        {
            _content.CopyToParentArray(array, arrayIndex);
        }

        public bool Remove(IEntityComponent item)
        {
            return _content.RemoveParentItem(item);
        }
    }
}