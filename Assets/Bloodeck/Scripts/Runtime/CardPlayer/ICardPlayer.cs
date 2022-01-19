namespace Bloodeck
{
    public interface ICardPlayer : ICardPlayerData
    {
        void LoadDeckTemplate(IDeckTemplate deckTemplate);

        bool TryPlaceCard(ICard card, ICardSlot slot);
    }
}