namespace Bloodeck
{
    public interface ICardSlot : ICardSlotData
    {
        bool TrySetCard(ICard card);
    }
}