using Cysharp.Threading.Tasks;
using niscolas.UnityUtils.Async;
using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;

namespace Bloodeck
{
    public class CardPlayerController : ICardPlayer
    {
        public IDeck Deck
        {
            get => _humbleObject.Deck;
            set => _humbleObject.Deck = value;
        }

        public IDeckFromTemplateFactory DeckFromTemplateFactory => _humbleObject.DeckFromTemplateFactory;

        public ICardHand Hand => _humbleObject.Hand;

        public bool IsMakingMove => _humbleObject.IsMakingMove;

        public bool IsDrawingStartingCards => _humbleObject.IsDrawingStartingCards;

        public float DrawCardIntervalSeconds => _humbleObject.DrawCardIntervalSeconds;

        public int InitialDrawCardsCount => _humbleObject.InitialDrawCardsCount;

        public int Energy
        {
            get => _humbleObject.Energy;
            set => _humbleObject.Energy = ProcessNewEnergyValue(value);
        }

        public ICardPlayerEnvironment Environment => _humbleObject.Environment;

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

        public void DrawCard()
        {
            ICard topCard = Deck.DrawFromTop();
            Hand.Add(topCard);
        }

        public void DrawInitialCards()
        {
            DrawInitialCardsAsync().Forget();
        }

        public bool TryPlaceCard(ICard card, ICardSlot slot)
        {
            if (!CheckCanPlaceCardOnSlot(card, slot))
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

        public void UseDeckTemplate(IDeckTemplate deckTemplate)
        {
            Deck = DeckFromTemplateFactory.Create(deckTemplate);
        }

        private bool CheckCanPlaceCardOnSlot(ICard card, ICardSlot slot)
        {
            return CheckHasCard(card) &&
                   CheckOwnsSlot(slot) &&
                   CheckHaveEnergyToPlaceCard(card);
        }

        private bool CheckHasCard(ICard card)
        {
            bool result = Hand.Contains(card);
            return result;
        }

        private bool CheckHaveEnergyToPlaceCard(ICard card)
        {
            bool result = Energy >= card.Cost;
            return result;
        }

        private bool CheckOwnsSlot(ICardSlot slot)
        {
            bool result = Environment.Slots.Contains(slot);
            return result;
        }

        private async UniTaskVoid DrawInitialCardsAsync()
        {
            for (int i = 0; i < InitialDrawCardsCount; i++)
            {
                DrawCard();
                await Await.Seconds(DrawCardIntervalSeconds);
            }
        }

        private void OnCardSuccessfullyPlaced(ICard card)
        {
            Energy -= card.Cost;
            Hand.Remove(card);
        }

        private int ProcessNewEnergyValue(int value)
        {
            return Mathf.Clamp(value, 0, MaxEnergy);
        }
    }
}