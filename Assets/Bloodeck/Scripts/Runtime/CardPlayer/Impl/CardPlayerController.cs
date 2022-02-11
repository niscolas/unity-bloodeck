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

        public ICardHand Hand => _humbleObject.Hand;

        public bool IsMakingMove => _humbleObject.IsMakingMove;

        public bool HasDrawnInitialCards => _humbleObject.HasDrawnInitialCards;

        public bool IsDrawingStartingCards => _humbleObject.IsDrawingStartingCards;

        public float DrawCardIntervalSeconds => _humbleObject.DrawCardIntervalSeconds;

        public int InitialDrawCardsCount => _humbleObject.InitialDrawCardsCount;

        public int CardDrawCost => _humbleObject.CardDrawCost;

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

        private readonly ICardPlayerHumbleObject _humbleObject;

        public CardPlayerController(ICardPlayerHumbleObject humbleObject)
        {
            _humbleObject = humbleObject;
        }

        public void DrawCard(bool useEnergy = true)
        {
            if (CheckCanDrawCard())
            {
                return;
            }

            DrawCardRaw(useEnergy);
        }

        public void DrawCardRaw(bool useEnergy = true)
        {
            ICard topCard = Deck.DrawFromTop();
            Hand.Add(topCard);
            if (useEnergy)
            {
                DecreaseEnergyByCardDrawCost();
            }
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
                OnCardDeployed(card);
            }

            return wasAbleToPlaceCard;
        }

        public void UseDeckTemplate(IDeckTemplate deckTemplate)
        {
            Deck.LoadTemplate(deckTemplate);
            SetDeckCardsOwner();
        }

        private bool CheckCanDrawCard()
        {
            return Energy < CardDrawCost ||
                   Deck.Cards.CheckIsEmpty() ||
                   Hand.CheckIsFull();
        }

        private void DecreaseEnergyByCardDrawCost()
        {
            Energy -= CardDrawCost;
        }

        private void SetDeckCardsOwner()
        {
            Deck.Cards.ForEach(x => x.Owner = (ICardPlayer) _humbleObject);
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
                DrawCard(false);
                await Await.Seconds(DrawCardIntervalSeconds);
            }

            SetHasDrawnInitialCards(true);
        }

        private void OnCardDeployed(ICard card)
        {
            Energy -= card.Cost;
            Hand.Remove(card);
        }

        private int ProcessNewEnergyValue(int value)
        {
            return Mathf.Clamp(value, 0, MaxEnergy);
        }

        private void SetHasDrawnInitialCards(bool value)
        {
            _humbleObject.SetHasDrawnInitialCards(value);
        }
    }
}