using UnityEngine;

namespace Bloodeck
{
    [CreateAssetMenu(
        fileName = "CardSlotRestriction",
        menuName = Constants.CreateAssetMenuPrefix + "Card Slot Restriction",
        order = Constants.CreateAssetMenuOrder)]
    public class CardSlotRestrictionSO : ScriptableObject, ICardSlotRestriction
    {
        [SubclassSelector, SerializeReference]
        private ICardSlotRestriction _logic;

        public bool Validate(ICard card)
        {
            return _logic.Validate(card);
        }
    }
}