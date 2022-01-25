using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Deck")]
    public class DeckMB : CachedMB, IDeck
    {
        [SerializeField]
        private DeckTemplateSO _template;

        [Header(HeaderTitles.Debug)]
        [SerializeField]
        private CardMBCollection _cards = new CardMBCollection();

        public ICardFromTemplateFactory CardFromTemplateFactory => _cardFromTemplateFactory;

        public ICards Cards => _cards;

        [Inject]
        public IDeckShuffler Shuffler { get; }

        public IDeckTemplate Template
        {
            get => _template;
            set => _template = value as DeckTemplateSO;
        }

        [Inject]
        private CardMBFromTemplateFactory _cardFromTemplateFactory;

        [Inject]
        private DeckController _controller;

        [Inject]
        private IDespawnService _despawnService;

        private void Start()
        {
            if (CheckHasLoadedTemplate())
            {
                return;
            }

            LoadTemplate(_template);
        }

        public ICard DrawFromTop()
        {
            return _controller.DrawFromTop();
        }

        public void LoadTemplate(IDeckTemplate template)
        {
            DestroyAllCards();
            _controller.LoadTemplate(template);
            ParentAllCardsToSelf();
        }

        private bool CheckHasLoadedTemplate()
        {
            return !_controller.LoadedTemplate.IsUnityNull();
        }

        private void DestroyAllCards()
        {
            _cards.Content.ForEach(x => _despawnService.Despawn(x));
        }

        private void ParentAllCardsToSelf()
        {
            _cards.Content.ForEach(x => x.transform.SetParent(_transform));
        }
    }
}