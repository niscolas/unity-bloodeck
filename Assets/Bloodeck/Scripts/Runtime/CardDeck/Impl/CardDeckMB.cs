using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Deck")]
    public class CardDeckMB : CachedMB, ICardDeck
    {
        [SerializeField]
        private CardDeckTemplateSO _template;

        [Header(HeaderTitles.Debug)]
        [SerializeField]
        private CardMBCollection _cards = new CardMBCollection();

        [Inject]
        public ICardFromTemplateFactory CardFromTemplateFactory { get; private set; }

        public ICards Cards => _cards;

        [Inject]
        public ICardDeckShuffler Shuffler { get; }

        public ICardDeckTemplate Template
        {
            get => _template;
            set => _template = value as CardDeckTemplateSO;
        }

        [Inject]
        private CardDeckController _controller;

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

        public void LoadTemplate(ICardDeckTemplate template)
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
            _cards.AsMBs.ForEach(x => _despawnService.Despawn(x));
        }

        private void ParentAllCardsToSelf()
        {
            _cards.AsMBs.ForEach(x => x.transform.SetParent(_transform));
        }
    }
}