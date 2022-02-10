using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck.View.VisualScripting
{
    public class CardSlotVSVariables : CachedMB
    {
        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private CardDraggerMB _cardDragger;

        public CardDraggerMB CardDragger => _cardDragger;
    }
}