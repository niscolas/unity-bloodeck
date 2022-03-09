using System;
using System.Collections;
using System.Collections.Generic;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Deck")]
    public class DeckMB : CachedMB, IDeck, IDeckHumbleObject, ITemplatable<DeckTemplateSO>
    {
        [SerializeField]
        private DeckTemplateSO _templateToLoad;

        [SerializeField]
        private IntReference _count = new IntReference();

        [SerializeField]
        private Transform _cardsParent;

        [Header(HeaderTitles.Debug)]
        [SerializeField]
        private ParentList<ICard, CardMB> _cards = new ParentList<ICard, CardMB>();

        [SerializeField]
        private DeckTemplateSO _loadedTemplate;

        public event Action<ICard> CardCreated;
        public event Action<ICard> Added;
        public event Action Changed;

        public int Count => Cards.Count;

        public ICardFromTemplateFactory CardFromTemplateFactory => _cardFromTemplateFactory;

        public IList<ICard> Cards => _cards;

        [Inject]
        public IDeckShuffler Shuffler { get; }

        public DeckTemplateSO TemplateToLoad => _templateToLoad;

        DeckTemplateSO ITemplatable<DeckTemplateSO>.LoadedTemplate => _loadedTemplate;

        public IDeckTemplate LoadedTemplate => _loadedTemplate;

        [Inject]
        private CardMBFromTemplateFactory _cardFromTemplateFactory;

        [Inject]
        private DeckController _controller;

        [Inject]
        private IDespawnService _despawnService;

        private IDeck _asIDeck;

        protected override void Awake()
        {
            base.Awake();
            _asIDeck = this;
        }

        private void Start()
        {
            if (!_cardsParent)
            {
                _cardsParent = _transform;
            }

            _controller.Added += OnAdded;
            _controller.CardCreated += OnCardCreated;
            _controller.Changed += OnChanged;

            SimpleTemplateLoader<DeckTemplateSO>.InitializationLoadTemplate(this);
        }

        private void OnDestroy()
        {
            _controller.Added -= OnAdded;
            _controller.CardCreated -= OnCardCreated;
            _controller.Changed -= OnChanged;
        }

        public ICard DrawFromTop()
        {
            return _controller.DrawFromTop();
        }

        public bool ReturnCard(ICard card)
        {
            return _controller.ReturnCard(card);
        }

        public void Add(ICard card)
        {
            _controller.Add(card);

            CardInDeckMB cardInDeck = card.GetComponent<CardInDeckMB>();
            cardInDeck.Link(this);
            cardInDeck.transform.SetParent(_transform);
        }

        public bool Remove(ICard card)
        {
            bool result = _controller.Remove(card);
            card.GetComponent<CardInDeckMB>().Unlink();
            return result;
        }

        public bool Contains(ICard card)
        {
            return _cards.Contains(card);
        }

        public IEnumerator<ICard> GetEnumerator()
        {
            return _controller.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _controller.GetEnumerator();
        }

        public void LoadTemplate(IDeckTemplate template)
        {
            DestroyAllCards();
            _controller.LoadTemplate(template);
            ParentAllCardsToSelf();
        }

        public void SetHumbleObjectLoadedTemplate(IDeckTemplate template)
        {
            _loadedTemplate = template as DeckTemplateSO;
        }

        public void LoadTemplate(DeckTemplateSO template)
        {
            _asIDeck.LoadTemplate(template);
        }

        private void UpdateCountOutput()
        {
            _count.Value = _cards.Count;
        }

        private void DestroyAllCards()
        {
            _cards.AsChildClass.ForEach(x => _despawnService.Despawn(x));
        }

        private void OnAdded(ICard card)
        {
            Added?.Invoke(card);

            CardMB cardMB = (CardMB) card;
            ParentCard(cardMB);
        }

        private void OnCardCreated(ICard card) { }

        private void OnChanged()
        {
            UpdateCountOutput();
            Changed?.Invoke();
        }

        private void ParentAllCardsToSelf()
        {
            _cards.AsChildClass.ForEach(ParentCard);
        }

        private void ParentCard(CardMB card)
        {
            card.transform.SetParent(_cardsParent);
        }
    }
}