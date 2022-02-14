using System;
using niscolas.UnityUtils.Core;
using UnityEngine;

namespace Bloodeck
{
    public class CardInHandMB : CachedMB
    {
        [Header(HeaderTitles.Debug)]
        [SerializeField]
        public CardHandMB _hand;

        public event Action<CardHandMB> Linked;
        public event Action Unlinked;

        public CardHandMB Hand => _hand;

        public void LinkHand(CardHandMB hand)
        {
            _hand = hand;
            Linked?.Invoke(hand);
        }

        public void UnlinkHand()
        {
            _hand = default;
            Unlinked?.Invoke();
        }
    }
}