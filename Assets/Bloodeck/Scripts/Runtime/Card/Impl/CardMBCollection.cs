using System;
using System.Collections.Generic;
using niscolas.UnityUtils.Core;

namespace Bloodeck
{
    [Serializable]
    public class CardMBCollection : ParentList<ICard, CardMB>, ICards
    {
        public List<CardMB> Content => _content;
    }
}