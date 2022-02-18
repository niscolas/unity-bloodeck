using System;

namespace Bloodeck
{
    public interface ICardPlayer : ICardPlayerData
    {
        event Action<ICard> CardDeployed;
        void DrawCard(bool useEnergy = true);
        void DrawCardRaw(bool useEnergy = true);
        void DrawInitialCards();
        bool CheckCanDeployCardOnSlot(ICard card, ICardSlot slot);
        void UseDeckTemplate(IDeckTemplate deckTemplate);
        bool TryPlaceCard(ICard card, ICardSlot slot);
    }
}