using System;
using System.Collections.Generic;
using niscolas.UnityUtils.Core;

namespace Bloodeck
{
    [Serializable]
    public class MBCollection<TBase, TChild> : ParentCollection<TBase, TChild>, ICollection<TChild> where TChild : TBase
    {
        IEnumerator<TChild> IEnumerable<TChild>.GetEnumerator()
        {
            return _content.GetEnumerator();
        }

        public void Add(TChild item)
        {
            _content.Add(item);
        }

        public bool Contains(TChild item)
        {
            return _content.Contains(item);
        }

        public void CopyTo(TChild[] array, int arrayIndex)
        {
            _content.CopyTo(array, arrayIndex);
        }

        public bool Remove(TChild item)
        {
            return _content.Remove(item);
        }
    }
}