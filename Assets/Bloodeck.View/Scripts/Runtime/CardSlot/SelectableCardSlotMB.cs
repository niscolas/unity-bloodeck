using System;
using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Bloodeck.View
{
    public class SelectableCardSlotMB : CachedMB
    {
        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private CardSlotMB _selfCardSlot;

        [Inject, SerializeField]
        private CardDeployerMB _cardDeployer;

        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent _onSelected;

        [SerializeField]
        private UnityEvent _onDeselected;

        public event Action Selected;
        public event Action Deselected;

        public void Select()
        {
            NotifySelected();
        }

        public void Deselect()
        {
            NotifyDeselected();
        }

        private void NotifySelected()
        {
            Selected?.Invoke();
            _onSelected?.Invoke();
        }

        private void NotifyDeselected()
        {
            Deselected?.Invoke();
            _onDeselected?.Invoke();
        }
    }
}