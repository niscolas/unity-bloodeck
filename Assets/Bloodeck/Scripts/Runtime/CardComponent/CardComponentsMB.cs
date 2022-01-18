using System.Collections;
using System.Collections.Generic;
using System.Linq;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Components")]
    public class CardComponentsMB : CachedMB, ICardComponents
    {
        [SerializeField]
        private List<CardComponentMB> _content = new List<CardComponentMB>();

        public int Count => _content.Count;

        public bool IsReadOnly => false;

        public bool TryGet<T>(out T value) where T : ICardComponent
        {
            return _content.TryGetFirstOfType(out value);
        }

        public IEnumerator<ICardComponent> GetEnumerator()
        {
            return _content.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(ICardComponent item)
        {
            _content.AddParentItem(item);
        }

        public void Clear()
        {
            _content.Clear();
        }

        public bool Contains(ICardComponent item)
        {
            return _content.ContainsParentItem(item);
        }

        public void CopyTo(ICardComponent[] array, int arrayIndex)
        {
            _content.CopyToParentArray(array, arrayIndex);
        }

        public bool Remove(ICardComponent item)
        {
            return _content.RemoveParentItem(item);
        }
    }
}