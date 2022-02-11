using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    public class CardFromHandMB : CachedMB
    {
        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private CardMB _card;

        [Header(HeaderTitles.Debug)]
        [SerializeField]
        public CardHandMB _hand;

        public CardHandMB Hand => _hand;

        public void LinkHand(CardHandMB hand)
        {
            _hand = hand;

            if (_hand && !_hand.Contains(_card))
            {
                _hand.Add(_card);
            }
        }

        public void UnlinkHand()
        {
            if (_hand && _hand.Contains(_card))
            {
                _hand.Remove(_card);
            }

            _hand = default;
        }
    }
}