using System;
using niscolas.UnityUtils.Core;
using UnityEngine;

namespace Bloodeck
{
    public class CardPlayerStateNotifierMB : CachedMB, ICardPlayerStateNotifier
    {
        [Header(HeaderTitles.Debug)]
        [SerializeField]
        private CardPlayerStateTagSO _currentStateTag;

        public event Action<ICardPlayerStateTag> StateChanged;

        public void SetNewState(CardPlayerStateTagSO stateTag)
        {
            _currentStateTag = stateTag;
            StateChanged?.Invoke(stateTag);
        }
    }
}