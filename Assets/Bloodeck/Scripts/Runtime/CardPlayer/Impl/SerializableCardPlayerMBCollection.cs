using System;
using System.Collections.Generic;
using niscolas.UnityUtils.Core;

namespace Bloodeck
{
    [Serializable]
    public class SerializableCardPlayerMBCollection : ParentCollection<ICardPlayer, CardPlayerMB>, ICardPlayers,
        ICollection<CardPlayerMB>
    {
        IEnumerator<CardPlayerMB> IEnumerable<CardPlayerMB>.GetEnumerator()
        {
            return _content.GetEnumerator();
        }

        public void Add(CardPlayerMB item)
        {
            _content.Add(item);
        }

        public bool Contains(CardPlayerMB item)
        {
            return _content.Contains(item);
        }

        public void CopyTo(CardPlayerMB[] array, int arrayIndex)
        {
            _content.CopyTo(array, arrayIndex);
        }

        public bool Remove(CardPlayerMB item)
        {
            return _content.Remove(item);
        }
    }
}