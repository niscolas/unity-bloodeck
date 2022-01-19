﻿using NaughtyAttributes;
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
        private CardDeckMB _deck;

        [Header(HeaderTitles.Debug)]
        [ReadOnly, SerializeField]
        private SerializableCardHand _cards = new SerializableCardHand();

        public ICardPlayerEnvironment Environment => _environment;

        public ICardDeck Deck
        {
            get => _deck;
            set => _deck = value as CardDeckMB;
        }

        [Inject]
        public ICardDeckFromTemplateFactory DeckFromTemplateFactory { get; }

        public int Energy { get; set; }

        public ICardHand Hand => _cards;

        public int MaxEnergy { get; set; }

        [Inject]
        private CardPlayerController _controller;

        public void LoadDeckTemplate(ICardDeckTemplate deckTemplate)
        {
            _controller.LoadDeckTemplate(deckTemplate);
        }

        public bool TryPlaceCard(ICard card, ICardSlot slot)
        {
            return _controller.TryPlaceCard(card, slot);
        }
    }
}