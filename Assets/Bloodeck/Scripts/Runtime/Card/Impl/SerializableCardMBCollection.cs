using System;
using System.Collections.Generic;
using niscolas.UnityUtils.Core;

namespace Bloodeck
{
    [Serializable]
    public class SerializableCardMBCollection : ParentList<ICard, CardMB>, ICards
    {
        public List<CardMB> Content => _content;

        public ICollection<CardMB> AsMBs => _content;
    }
}