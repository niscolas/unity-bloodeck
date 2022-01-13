namespace Bloodeck
{
    public interface ICardSlot
    {
        ICard Card { get; }
        
        ICardSlotRestrictions CardRestrictions { get; }

        bool TrySetCard(ICard card);
    }
}