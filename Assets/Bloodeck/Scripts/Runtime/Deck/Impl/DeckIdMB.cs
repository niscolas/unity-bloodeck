using System.Collections.Generic;
using UnityEngine;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Deck ID")]
    public class DeckIdMB : IdMB<DeckMB, DeckIdMB, SerializableDeckMBCollection, List<DeckIdMB>> { }
}