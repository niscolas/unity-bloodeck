namespace Bloodeck
{
    public interface ICardSlot : ICardSlotData
    {
        bool CanPlaceCard(ICard card);

        bool TrySetCard(ICard card);

        bool UnsetCard();
    }
}