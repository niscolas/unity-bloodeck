using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Slot")]
    public class CardSlotMB : CachedMB, ICardSlot
    {
        [SerializeReference, SubclassSelector]
        private ICardSlotRestrictions _restrictions;

        [Header(HeaderTitles.Debug)]
        [ReadOnly, SerializeField]
        private CardMB _card;

        public ICard Card
        {
            get => _card;
            set => _card = value as CardMB;
        }

        public ICardSlotRestrictions Restrictions => _restrictions;

        public bool HasCard => _card;

        [Inject]
        private CardSlotController _controller;

        public bool CanPlaceCard(ICard card)
        {
            return _controller.CanPlaceCard(card);
        }

        public bool TrySetCard(ICard card)
        {
            return _controller.TrySetCard(card);
        }
    }
}