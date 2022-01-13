namespace Bloodeck
{
    public class IsSpellCardSlotRestriction : ICardSlotRestriction
    {
        public bool Validate(ICard card)
        {
            return false;
        }
    }
}