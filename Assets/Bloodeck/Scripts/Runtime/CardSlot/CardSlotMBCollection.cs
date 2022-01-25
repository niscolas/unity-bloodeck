using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using niscolas.UnityUtils.Core;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public class CardSlotMBCollection : ParentCollection<ICardSlot, CardSlotMB>, ICardSlots
    {
        public CardSlotMBCollection() { }
        public CardSlotMBCollection(IEnumerable<CardSlotMB> content) : base(content) { }
        public CardSlotMBCollection(params CardSlotMB[] content) : base(content) { }
    }
}