using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Player")]
    public class CardPlayerMB : CachedMB, ICardPlayer
    {
        [SerializeField]
        private DeckMB _deck;

        [Header(HeaderTitles.Debug)]
        [ReadOnly, SerializeField]
        private SerializableCardHand _cards = new SerializableCardHand();

        [ShowNativeProperty]
        private string _environmentDebug => _environment.Value ? _environment.Value.ToString() : "null";

        public ICardPlayerEnvironment Environment => _environment.Value;

        public IDeck Deck
        {
            get => _deck;
            set => _deck = value as DeckMB;
        }


        public IDeckFromTemplateFactory DeckFromTemplateFactory => _deckFromTemplateFactory;

        public int Energy { get; set; }

        [Inject]
        private LazyInject<CardPlayerEnvironmentMB> _environment;

        public ICardHand Hand => _cards;

        public int MaxEnergy { get; set; }

        [Inject]
        private CardPlayerController _controller;

        [Inject]
        private DeckMBFromTemplateFactory _deckFromTemplateFactory;

        public void DrawCard()
        {
            _controller.DrawCard();
        }

        public void UseDeckTemplate(IDeckTemplate deckTemplate)
        {
            _controller.UseDeckTemplate(deckTemplate);
        }

        public bool TryPlaceCard(ICard card, ICardSlot slot)
        {
            return _controller.TryPlaceCard(card, slot);
        }
    }
}