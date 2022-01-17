namespace Bloodeck
{
    public interface ICardPlayer : ICardPlayerData
    {
        void LoadDeck(ICardDeck deck);

        bool TryPlaceCard(ICard card, ICardSlot slot);
    }
}