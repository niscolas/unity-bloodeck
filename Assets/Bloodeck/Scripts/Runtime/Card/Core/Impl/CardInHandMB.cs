using System;
using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Bloodeck
{
    public class CardInHandMB : CachedMB
    {
        [Header(HeaderTitles.Debug)]
        [SerializeField]
        public CardHandMB _hand;

        [SerializeField]
        private IntReference _timesLinked = new IntReference();

        public event Action<CardHandMB> Linked;
        public event Action Unlinked;

        public CardHandMB Hand => _hand;

        public int TimesLinked
        {
            get => _timesLinked.Value;
            private set => _timesLinked.Value = value;
        }

        public bool IsLinked { get; private set; }

        public void LinkHand(CardHandMB hand)
        {
            TimesLinked++;
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