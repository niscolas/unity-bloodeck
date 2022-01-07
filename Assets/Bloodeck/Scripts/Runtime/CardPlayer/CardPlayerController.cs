using UnityEngine;

namespace Bloodeck
{
    public class CardPlayerController : ICardPlayer
    {
        public ICards Cards
        {
            get => _humbleObject.Cards;
            set => _humbleObject.Cards = value;
        }

        public int Energy
        {
            get => _humbleObject.Energy;
            set => _humbleObject.Energy = ProcessNewEnergyValue(value);
        }

        public int MaxEnergy
        {
            get => _humbleObject.MaxEnergy;
            set => _humbleObject.MaxEnergy = value;
        }

        private readonly ICardPlayerData _humbleObject;

        public CardPlayerController(ICardPlayerData humbleObject)
        {
            _humbleObject = humbleObject;
        }

        public bool TryPlaceCard(ICard card, ICardSlot slot)
        {
            if (!Cards.Contains(card) || !CheckHaveEnergyToPlaceCard(card))
            {
                return false;
            }

            bool wasAbleToPlaceCard = slot.TrySetCard(card);

            if (wasAbleToPlaceCard)
            {
                OnCardSuccessfullyPlaced(card);
            }

            return wasAbleToPlaceCard;
        }

        private bool CheckHaveEnergyToPlaceCard(ICard card)
        {
            return Energy >= card.Cost;
        }

        private void OnCardSuccessfullyPlaced(ICard card)
        {
            Energy -= card.Cost;
            Cards.Remove(card);
        }

        private int ProcessNewEnergyValue(int value)
        {
            return Mathf.Clamp(value, 0, MaxEnergy);
        }
    }
}