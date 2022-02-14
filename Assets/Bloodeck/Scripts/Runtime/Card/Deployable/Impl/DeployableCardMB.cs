using System;
using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Bloodeck
{
    public class DeployableCardMB : CachedMB, IDeployableCard, IDeployableCardHumbleObject
    {
        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent _onDeployed;

        [SerializeField]
        private UnityEvent _onUndeployed;

        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private CardMB _card;

        [Header(HeaderTitles.Debug)]
        [SerializeField]
        private CardSlotMB _slot;

        public event Action Deployed;
        public event Action Undeployed;

        [ShowNativeProperty]
        public bool IsDeployed => _slot;

        public ICard SelfCard => _card;

        public ICardSlot Slot
        {
            get => _slot;
            private set => _slot = value as CardSlotMB;
        }

        [Inject]
        private DeployableCardController _controller;

        private void Start()
        {
            _controller.Deployed += OnDeployed;
            _controller.Undeployed += OnUndeployed;
        }

        private void OnDestroy()
        {
            _controller.Deployed -= OnDeployed;
            _controller.Undeployed -= OnUndeployed;
        }

        public bool CheckIsDeployed()
        {
            return _controller.CheckIsDeployed();
        }

        public bool TryDeploy(ICardSlot slot)
        {
            return _controller.TryDeploy(slot);
        }

        public bool TryUndeploy()
        {
            return _controller.TryUndeploy();
        }

        public void SetSlot(ICardSlot slot)
        {
            _slot = slot as CardSlotMB;
        }

        private void OnDeployed()
        {
            Deployed?.Invoke();
            _onDeployed?.Invoke();
        }

        private void OnUndeployed()
        {
            Undeployed?.Invoke();
            _onUndeployed?.Invoke();
        }
    }
}