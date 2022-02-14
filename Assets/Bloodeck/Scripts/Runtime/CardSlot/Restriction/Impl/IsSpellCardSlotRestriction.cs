using System;

namespace Bloodeck
{
    [Serializable]
    public class IsSpellCardSlotRestriction : ICardSlotRestriction
    {
        public bool Validate(ICard card)
        {
            return false;
        }
    }
}