namespace Bloodeck
{
    public interface ICardPlayer : ICardPlayerData
    {
        void DrawCard();

        void DrawInitialCards();

        void UseDeckTemplate(IDeckTemplate deckTemplate);

        bool TryPlaceCard(ICard card, ICardSlot slot);
    }
}