using System;
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

        [Header(HeaderTitles.Debug)]
        [SerializeField]
        private SerializableCardMBCollection _cards = new SerializableCardMBCollection();

        [SerializeField]
        private DeckTemplateSO _loadedTemplate;

        public ICardFromTemplateFactory CardFromTemplateFactory => _cardFromTemplateFactory;

        public ICards Cards => _cards;

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
            _cards.Changed += Cards_OnChanged;
            SimpleTemplateLoader<DeckTemplateSO>.InitializationLoadTemplate(this);
        }

        private void OnDestroy()
        {
            _cards.Changed -= Cards_OnChanged;
        }

        public ICard DrawFromTop()
        {
            return _controller.DrawFromTop();
        }

        public void LoadTemplate(IDeckTemplate template)
        {
            DestroyAllCards();
            _controller.LoadTemplate(template, OnCardCreated);
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

        private void Cards_OnChanged()
        {
            UpdateCountOutput();
        }

        private void UpdateCountOutput()
        {
            _count.Value = _cards.Count;
        }

        private void DestroyAllCards()
        {
            _cards.AsMBs.ForEach(x => _despawnService.Despawn(x));
        }

        private void OnCardCreated(ICard card)
        {
            CardMB cardMB = (CardMB) card;
            cardMB.gameObject.SetActive(false);
        }

        private void ParentAllCardsToSelf()
        {
            _cards.AsMBs.ForEach(x => x.transform.SetParent(_transform));
        }
    }
}