using System.Collections.Generic;
using UnityEngine;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Player Environment ID")]
    public class CardPlayerEnvironmentIdMB :
        IdMB<CardPlayerEnvironmentMB,
            CardPlayerEnvironmentIdMB,
            SerializableCardPlayerEnvironmentMBCollection,
            List<CardPlayerEnvironmentIdMB>> { }
}