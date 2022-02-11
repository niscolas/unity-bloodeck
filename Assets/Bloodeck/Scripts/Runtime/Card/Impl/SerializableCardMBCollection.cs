using System;
using System.Collections.Generic;

namespace Bloodeck
{
    [Serializable]
    public class SerializableCardMBCollection : WatchableParentList<ICard, CardMB>, ICards
    {
        public IList<CardMB> AsMBs => _content;
    }
}