using System;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public struct SerializableCardHand : ICardHand
    {
        [SerializeField]
        private CardMBCollection _cards;

        public ICards Cards => _cards;
    }
}