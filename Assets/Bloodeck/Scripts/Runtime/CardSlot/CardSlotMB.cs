using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Slot")]
    public class CardSlotMB : CachedMB, ICardSlot
    {
        [SerializeField]
        private CardSlotRestrictionSOCollection _restrictions;

        [Header(HeaderTitles.Debug)]
        [ReadOnly, SerializeField]
        private CardMB _card;

        public ICard Card => _card;

        public ICardSlotRestrictions CardRestrictions => _restrictions;

        [Inject]
        private CardSlotController _controller;

        public bool TrySetCard(ICard card)
        {
            return _controller.TrySetCard(card);
        }
    }
}