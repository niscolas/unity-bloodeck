namespace Bloodeck
{
    public interface ICardSlotRestriction
    {
        bool Validate(ICard card);
    }
}