namespace Bloodeck
{
    public interface ICardPlayer : ICardPlayerData
    {
        bool TryPlaceCard(ICard card, ICardSlot slot);
    }
}