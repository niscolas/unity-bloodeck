using System;
using System.Collections.Generic;
using niscolas.UnityUtils.Core;

namespace Bloodeck
{
    [Serializable]
    public class CardPlayerEnvironmentMBCollection :
        ParentCollection<ICardPlayerEnvironment, CardPlayerEnvironmentMB>,
        ICardPlayerEnvironments, ICardPlayerEnvironmentMBCollection
    {
        IEnumerator<CardPlayerEnvironmentMB> IEnumerable<CardPlayerEnvironmentMB>.GetEnumerator()
        {
            return _content.GetEnumerator();
        }

        public void Add(CardPlayerEnvironmentMB item)
        {
            _content.Add(item);
        }

        public bool Contains(CardPlayerEnvironmentMB item)
        {
            return _content.Contains(item);
        }

        public void CopyTo(CardPlayerEnvironmentMB[] array, int arrayIndex)
        {
            _content.CopyTo(array, arrayIndex);
        }

        public bool Remove(CardPlayerEnvironmentMB item)
        {
            return _content.Remove(item);
        }
    }
}