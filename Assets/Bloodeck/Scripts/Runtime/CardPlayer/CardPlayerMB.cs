using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Player")]
    public class CardPlayerMB : CachedMB, ICardPlayer
    {
        [SerializeField]
        private CardPlayerEnvironmentMB _environment;

        [SerializeField]
        private DeckMB _deck;

        [Header(HeaderTitles.Debug)]
        [ReadOnly, SerializeField]
        private SerializableCardHand _cards = new SerializableCardHand();

        public ICardPlayerEnvironment Environment => _environment;

        public IDeck Deck
        {
            get => _deck;
            set => _deck = value as DeckMB;
        }

        [Inject]
        public IDeckFromTemplateFactory DeckFromTemplateFactory { get; }

        public int Energy { get; set; }

        public ICardHand Hand => _cards;

        public int MaxEnergy { get; set; }

        [Inject]
        private CardPlayerController _controller;

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