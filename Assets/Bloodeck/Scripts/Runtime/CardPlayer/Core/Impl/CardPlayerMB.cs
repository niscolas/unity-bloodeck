using System;
using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Player")]
    public class CardPlayerMB : CachedMB, ICardPlayer, ICardPlayerHumbleObject
    {
        [SerializeField]
        private FloatReference _drawCardIntervalSeconds = new FloatReference(0.1f);

        [SerializeField]
        private IntReference _initialDrawCardCount = new IntReference(4);

        [SerializeField]
        private IntReference _energy = new IntReference(1);

        [SerializeField]
        private IntReference _maxEnergy = new IntReference();

        [SerializeField]
        private IntReference _cardDrawCost = new IntReference();

        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent<CardMB> _onCardDeployed;

        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private EntityMB _selfEntity;

        [Inject, SerializeField]
        private CardPlayerStateNotifierMB _stateNotifier;

        [Inject, SerializeField]
        private DeckMB _deck;

        [Inject, SerializeField]
        private CardHandMB _hand;

        [Header(HeaderTitles.Debug)]
        [SerializeField]
        private BoolReference _hasDrawnInitialCards = new BoolReference(false);

        [SerializeField]
        private BoolReference _isMakingMove = new BoolReference(false);

        [SerializeField]
        private BoolReference _isDrawingInitialCards = new BoolReference(false);

        public event Action<ICard> CardDeployed;

        public ICardPlayerEnvironment Environment => _environment.Value;

        public IEntity SelfEntity => _selfEntity;

        public IDeck Deck
        {
            get => _deck;
            set => _deck = value as DeckMB;
        }

        public int CardDrawCost
        {
            get => _cardDrawCost.Value;
            set => _cardDrawCost.Value = value;
        }

        public int Energy
        {
            get => _energy.Value;
            set => _energy.Value = value;
        }

        [Inject]
        private LazyInject<CardPlayerEnvironmentMB> _environment;

        public ICardHand Hand => _hand;

        public ICardPlayerStateNotifier StateNotifier => _stateNotifier;

        public bool IsMakingMove
        {
            get => _isMakingMove.Value;
            set => _isMakingMove.Value = value;
        }

        public bool IsDrawingStartingCards => _isDrawingInitialCards.Value;

        public bool HasDrawnInitialCards => _hasDrawnInitialCards.Value;

        public float DrawCardIntervalSeconds => _drawCardIntervalSeconds.Value;

        public int InitialDrawCardsCount => _initialDrawCardCount.Value;

        public int MaxEnergy
        {
            get => _maxEnergy.Value;
            set => _maxEnergy.Value = value;
        }

        [Inject]
        private CardPlayerController _controller;

        private void Start()
        {
            _controller.CardDeployed += Controller_OnCardDeployed;
            DrawInitialCards();
        }

        private void OnDestroy()
        {
            _controller.CardDeployed -= Controller_OnCardDeployed;
        }

        public void DrawCard(bool useEnergy = true)
        {
            _controller.DrawCard(useEnergy);
        }

        public void DrawCardRaw(bool useEnergy = true)
        {
            _controller.DrawCardRaw(useEnergy);
        }

        public void DrawInitialCards()
        {
            _controller.DrawInitialCards();
        }

        public bool CheckCanDeployCardOnSlot(ICard card, ICardSlot slot)
        {
            return _controller.CheckCanDeployCardOnSlot(card, slot);
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

        private void Controller_OnCardDeployed(ICard card)
        {
            CardDeployed?.Invoke(card);
            _onCardDeployed?.Invoke(card as CardMB);
        }
    }
}