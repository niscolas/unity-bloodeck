using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using UnityEngine;

namespace Bloodeck.View
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Dragger")]
    public class CardDraggerMB : CachedMB
    {
        [Header(HeaderTitles.Debug)]
        [SerializeField]
        private CardMB _card;

        [ShowNativeProperty]
        public bool IsDragging => _card;

        public CardMB DraggedCard => _card;

        public void BeginDrag(CardMB card)
        {
            _card = card;
        }

        public void EndDrag()
        {
            _card = default;
        }
    }
}