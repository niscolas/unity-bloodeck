using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Player")]
    public class CardPlayerMB : CachedMB, ICardPlayer, ICardPlayerHumbleObject
    {
        [Inject, SerializeField]
        private DeckMB _deck;

        [Inject, SerializeField]
        private CardHandMB _hand;

        [SerializeField]
        private FloatReference _drawCardIntervalSeconds = new FloatReference(0.1f);

        [SerializeField]
        private IntReference _initialDrawCardCount = new IntReference(4);

        [Header(HeaderTitles.Debug)]
        [SerializeField]
        private BoolReference _hasDrawnInitialCards = new BoolReference(false);

        [SerializeField]
        private BoolReference _isMakingMove = new BoolReference(false);

        [SerializeField]
        private BoolReference _isDrawingInitialCards = new BoolReference(false);

        public ICardPlayerEnvironment Environment => _environment.Value;

        public IDeck Deck
        {
            get => _deck;
            set => _deck = value as DeckMB;
        }

        public int Energy { get; set; }

        [Inject]
        private LazyInject<CardPlayerEnvironmentMB> _environment;


        public ICardHand Hand => _hand;

        public bool IsMakingMove
        {
            get => _isMakingMove.Value;
            set => _isMakingMove.Value = value;
        }


        public bool IsDrawingStartingCards => _isDrawingInitialCards.Value;

        public bool HasDrawnInitialCards => _hasDrawnInitialCards.Value;

        public float DrawCardIntervalSeconds => _drawCardIntervalSeconds.Value;

        public int InitialDrawCardsCount => _initialDrawCardCount.Value;

        public int MaxEnergy { get; set; }

        [Inject]
        private CardPlayerController _controller;

        private void Start()
        {
            DrawInitialCards();
        }

        public void DrawCard()
        {
            _controller.DrawCard();
        }

        public void DrawInitialCards()
        {
            _controller.DrawInitialCards();
        }

        public void UseDeckTemplate(IDeckTemplate deckTemplate)
        {
            _controller.UseDeckTemplate(deckTemplate);
        }

        public bool TryPlaceCard(ICard card, ICardSlot slot)
        {
            return _controller.TryPlaceCard(card, slot);
        }

        public void SetHasDrawnInitialCards(bool value)
        {
            _hasDrawnInitialCards.Value = value;
        }
    }
}