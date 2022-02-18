using System;
using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityEngine.Events;

namespace Bloodeck
{
    public class OwnableCardMB : CachedMB, IOwnableCard
    {
        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent<CardPlayerMB> _onOwnerChanged;

        [Header(HeaderTitles.Debug)]
        [SerializeField]
        private CardPlayerMB _owner;

        [SerializeField]
        private CardPlayerMB _previousOwner;

        public event Action<ICardPlayer> OwnerChanged;
        public event Action<(ICardPlayer, ICardPlayer)> OwnerChangedWithHistory;

        public ICardPlayer Owner => _owner;
        public ICardPlayer PreviousOwner => _previousOwner;

        public void SetOwner(ICardPlayer owner)
        {
            _previousOwner = _owner;
            _owner = (CardPlayerMB) owner;
            NotifyOwnerChanged();
        }

        private void NotifyOwnerChanged()
        {
            OwnerChanged?.Invoke(_owner);
            OwnerChangedWithHistory?.Invoke((_owner, _previousOwner));
            _onOwnerChanged?.Invoke(_owner);
        }
    }
}