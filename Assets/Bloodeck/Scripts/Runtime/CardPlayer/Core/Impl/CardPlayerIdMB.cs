using UnityEngine;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Player ID")]
    public class CardPlayerIdMB :
        IdMB<CardPlayerMB, CardPlayerIdMB, SerializableCardPlayerMBCollection, SerializableCardPlayerIdMBCollection> { }
}