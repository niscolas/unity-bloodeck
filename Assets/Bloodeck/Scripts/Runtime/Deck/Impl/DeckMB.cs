using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Deck")]
    public class DeckMB : CachedMB, IDeck, IDeckHumbleObject
    {
        [SerializeField]
        private DeckTemplateSO _templateToLoad;

        [Header(HeaderTitles.Debug)]
        [ReadOnly, SerializeField]
        private SerializableCardMBCollection _cards = new SerializableCardMBCollection();

        [ReadOnly, SerializeField]
        private DeckTemplateSO _loadedTemplate;

        public ICardFromTemplateFactory CardFromTemplateFactory => _cardFromTemplateFactory;

        public ICards Cards => _cards;

        [Inject]
        public IDeckShuffler Shuffler { get; }

        public IDeckTemplate LoadedTemplate => _loadedTemplate;

        [Inject]
        private CardMBFromTemplateFactory _cardFromTemplateFactory;

        [Inject]
        private DeckController _controller;

        [Inject]
        private IDespawnService _despawnService;

        private void Start()
        {
            if (CheckShouldLoadTemplate())
            {
                LoadTemplateToLoad();
            }
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

        private bool CheckShouldLoadTemplate()
        {
            return _templateToLoad && _templateToLoad != _loadedTemplate;
        }

        private void DestroyAllCards()
        {
            _cards.Content.ForEach(x => _despawnService.Despawn(x));
        }

        private void LoadTemplateToLoad()
        {
            LoadTemplate(_templateToLoad);
        }

        private void OnCardCreated(ICard card)
        {
            CardMB cardMB = (CardMB) card;
            cardMB.gameObject.SetActive(false);
        }

        private void ParentAllCardsToSelf()
        {
            _cards.Content.ForEach(x => x.transform.SetParent(_transform));
        }
    }
}