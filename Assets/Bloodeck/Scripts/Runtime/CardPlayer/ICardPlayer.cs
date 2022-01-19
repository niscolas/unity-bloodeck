namespace Bloodeck
{
    public interface ICardPlayer : ICardPlayerData
    {
        void LoadDeckTemplate(ICardDeckTemplate deckTemplate);

        bool TryPlaceCard(ICard card, ICardSlot slot);
    }
}