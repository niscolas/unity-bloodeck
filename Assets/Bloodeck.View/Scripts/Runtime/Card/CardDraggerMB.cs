using niscolas.UnityUtils.Core;
using UnityEngine;

namespace Bloodeck.View
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Dragger")]
    public class CardDraggerMB : CachedMB
    {
        public bool IsDragging { get; }
    }
}