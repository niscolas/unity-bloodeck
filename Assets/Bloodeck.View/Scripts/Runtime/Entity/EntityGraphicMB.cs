using niscolas.UnityUtils.Core;
using UnityEngine;

namespace Bloodeck.View
{
    public abstract class EntityGraphicMB : CachedMB
    {
        public abstract Color Color { get; set; }
        public abstract Sprite Sprite { get; set; }
    }
}