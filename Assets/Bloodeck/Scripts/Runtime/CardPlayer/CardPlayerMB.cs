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

        [Header(HeaderTitles.Debug)]
        [ReadOnly, SerializeField]
        private CardMBCollection _cards = new CardMBCollection();

        public ICardPlayerEnvironment Environment => _environment;

        public ICards Cards
        {
            get => _cards;
            set => _cards = value as CardMBCollection;
        }

        public int Energy { get; set; }

        public int MaxEnergy { get; set; }

        [Inject]
        private CardPlayerController _controller;

        public bool TryPlaceCard(ICard card, ICardSlot slot)
        {
            return _controller.TryPlaceCard(card, slot);
        }
    }
}