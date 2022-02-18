using System;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Bloodeck.View
{
    public class CardOwnerStateListenerMB : CachedMB
    {
        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent<CardPlayerStateTagSO> _onOwnerStateChanged;

        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private CardMB _card;

        public event Action<ICardPlayerStateTag> OwnerStateChanged;

        private void Start()
        {
            _card.Ownable.Owner.StateNotifier.StateChanged += NotifyOwnerStateChanged;
        }

        private void OnDestroy()
        {
            _card.Ownable.Owner.StateNotifier.StateChanged -= NotifyOwnerStateChanged;
        }

        private void NotifyOwnerStateChanged(ICardPlayerStateTag stateTag)
        {
            OwnerStateChanged?.Invoke(stateTag);
            _onOwnerStateChanged?.Invoke((CardPlayerStateTagSO) stateTag);
        }
    }
}