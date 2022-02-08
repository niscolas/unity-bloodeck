using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Bloodeck.View
{
    public class HoverableCardMB : CachedMB
    {
        [Header(HeaderTitles.Debug)]
        [SerializeField]
        private BoolReference _isBeingHovered = new BoolReference();

        public bool IsBeingHovered
        {
            get => _isBeingHovered.Value;
            set => _isBeingHovered.Value = value;
        }
    }
}