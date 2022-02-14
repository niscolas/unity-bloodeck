using System;
using niscolas.UnityUtils.Core;
using UnityEngine;

namespace Bloodeck
{
    public class CardInDeckMB : CachedMB
    {
        [Header(HeaderTitles.Debug)]
        [SerializeField]
        private DeckMB _deck;

        public event Action<DeckMB> Linked;
        public event Action Unlinked;

        public DeckMB Deck => _deck;

        public void Link(DeckMB deck)
        {
            _deck = deck;
            Linked?.Invoke(deck);
        }

        public void Unlink()
        {
            _deck = default;
            Unlinked?.Invoke();
        }
    }
}