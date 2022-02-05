using System;
using System.Collections.Generic;

namespace Bloodeck
{
    [Serializable]
    public class CardHandIdMB :
        IdMB<CardHandMB, CardHandIdMB, SerializableCardHandMBCollection, List<CardHandIdMB>> { }
}