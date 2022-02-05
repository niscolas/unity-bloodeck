using System;

namespace Bloodeck
{
    [Serializable]
    public class SerializableCardHandMBCollection : MBCollection<ICardHand, CardHandMB>, ICardHands { }
}