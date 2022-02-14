using System;
using System.Collections.Generic;
using niscolas.UnityUtils.Core;

namespace Bloodeck
{
    [Serializable]
    public class SerializableDeckMBCollection :
        ParentCollection<IDeck, DeckMB>, IDecks, IDeckMBs
    {
        IEnumerator<DeckMB> IEnumerable<DeckMB>.GetEnumerator()
        {
            return _content.GetEnumerator();
        }

        public void Add(DeckMB item)
        {
            _content.Add(item);
        }

        public bool Contains(DeckMB item)
        {
            return _content.Contains(item);
        }

        public void CopyTo(DeckMB[] array, int arrayIndex)
        {
            _content.CopyTo(array, arrayIndex);
        }

        public bool Remove(DeckMB item)
        {
            return _content.Remove(item);
        }
    }
}