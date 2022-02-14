namespace Bloodeck
{
    public interface ICardPlayer : ICardPlayerData
    {
        void DrawCard(bool useEnergy = true);
        void DrawCardRaw(bool useEnergy = true);
        void DrawInitialCards();
        void UseDeckTemplate(IDeckTemplate deckTemplate);
        bool TryPlaceCard(ICard card, ICardSlot slot);
    }
}