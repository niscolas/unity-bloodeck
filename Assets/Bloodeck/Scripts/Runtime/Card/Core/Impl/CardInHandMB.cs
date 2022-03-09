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

        public bool IsLinked { get; private set; }

        public void LinkHand(CardHandMB hand)
        {
            _hand = hand;
            IsLinked = true;
            Linked?.Invoke(hand);
        }

        public void UnlinkHand()
        {
            _hand = default;
            IsLinked = false;
            Unlinked?.Invoke();
        }
    }
}