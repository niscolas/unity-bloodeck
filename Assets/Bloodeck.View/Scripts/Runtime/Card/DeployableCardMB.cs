using System;
using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Bloodeck.View
{
    public class DeployableCardMB : CachedMB
    {
        [SerializeField]
        private FloatReference _deployedSizeFactor = new FloatReference(0.5f);

        [SerializeField]
        private FloatReference _hoveringSizeFactor = new FloatReference(3f);

        [SerializeField]
        private FloatReference _hoveringSizeChangeSpeed = new FloatReference(10f);

        [SerializeField]
        private FloatReference _deploySpeed = new FloatReference(40f);

        [SerializeField]
        private FloatReference _maxDistanceFromSlot = new FloatReference(10);

        [SerializeField]
        private Vector3Reference _cardSlotCheckDir = new Vector3Reference(new Vector3(0, 0, 1));

        [SerializeField]
        private LayerMask _cardSlotCheckLayerMask;

        [SerializeField]
        private FloatReference _cardSlotCheckMaxDistance = new FloatReference(1000f);

        [SerializeField]
        private FloatReference _cardSlotCheckRadius = new FloatReference(15f);

        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent _onDeployed;

        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private CardMB _card;

        [Inject, SerializeField]
        private CardDeployerMB _cardDeployer;

        [Header(HeaderTitles.Debug)]
        [SerializeField]
        private BoolReference _isDeploying = new BoolReference();

        [SerializeField]
        private BoolReference _isDeployed = new BoolReference();

        [SerializeField]
        private BoolReference _canBeDeployed = new BoolReference();

        [SerializeField]
        private CardSlotMB _slot;

        [SerializeField]
        private SelectableCardSlotMB _selectableCardSlot;

        public event Action Deployed;

        public bool HasSelectedSlot => _slot;

        public bool IsDeploying => _isDeploying.Value;

        public bool IsDeployed => _isDeployed.Value;

        public bool CanBeDeployed
        {
            get => _canBeDeployed.Value;
            set => _canBeDeployed.Value = value;
        }

        private float DeployedSizeFactor => _deployedSizeFactor.Value;

        [Inject]
        private IUnityTimeService _timeService;

        private Vector3 _initialScale;

        private void Start()
        {
            _initialScale = _transform.localScale;
        }

        private void FixedUpdate()
        {
            if (IsDeployed)
            {
                return;
            }

            if (!IsDeploying)
            {
                if (!CanBeDeployed)
                {
                    ResetSelectedCardSlot();
                    return;
                }

                CheckCardSlot();
                HandleScaling();
            }
            else
            {
                HandleDeployingRaw();
            }
        }

        public void BeginDeploy()
        {
            _isDeploying.Value = true;
            _selectableCardSlot.Deselect();
        }

        private void HandleScaling()
        {
            float t = _timeService.DeltaTime * _hoveringSizeChangeSpeed.Value;

            if (!_slot)
            {
                _transform.localScale = Vector3.Lerp(
                    _transform.localScale, _initialScale, t);

                return;
            }

            _transform.localScale = Vector3.Lerp(
                _transform.localScale,
                _initialScale * _hoveringSizeFactor.Value,
                t);
        }

        private void HandleDeployingRaw()
        {
            if (CheckReachedSlot())
            {
                OnDeployed();
                return;
            }

            MoveTowardsSlot();
        }

        private void CheckCardSlot()
        {
            if (!TryDetectCardSlot(out RaycastHit hit))
            {
                ResetSelectedCardSlot();
                return;
            }

            _slot = hit.collider.GetComponentInChildren<CardSlotMB>();
            if (!_slot)
            {
                ResetSelectedCardSlot();
                return;
            }

            _selectableCardSlot = _slot.GetComponentInChildren<SelectableCardSlotMB>();
            _selectableCardSlot.Select();
        }

        private void ResetSelectedCardSlot()
        {
            _slot = default;

            if (_selectableCardSlot)
            {
                _selectableCardSlot.Deselect();
                _selectableCardSlot = default;
            }
        }

        private bool TryDetectCardSlot(out RaycastHit hit)
        {
            return Physics.Raycast(
                GetCardSlotCheckOrigin(),
                // _cardSlotCheckRadius.Value,
                GetCardSlotCheckDirection(),
                out hit,
                _cardSlotCheckMaxDistance.Value,
                _cardSlotCheckLayerMask);
        }

        private Vector3 GetCardSlotCheckDirection()
        {
            return _transform.TransformDirection(_cardSlotCheckDir.Value);
        }

        private Vector3 GetCardSlotCheckOrigin()
        {
            return _transform.position;
        }

        private bool CheckIsLinkedToSlot()
        {
            return (CardMB) _slot.Card == _card;
        }

        private bool CheckReachedSlot()
        {
            return Vector3.Distance(_transform.position, _slot.transform.position) < _maxDistanceFromSlot.Value;
        }

        private void MoveTowardsSlot()
        {
            float t = _timeService.DeltaTime * _deploySpeed.Value;
            _transform.localScale = Vector3.Lerp(
                _transform.localScale,
                _initialScale * DeployedSizeFactor,
                t);

            _transform.position = Vector3.Lerp(
                _transform.position,
                _slot.transform.position,
                t);
        }

        private void OnDeployed()
        {
            _slot.TrySetCard(_card);
            NotifyDeployed();
            _isDeployed.Value = true;
            _isDeploying.Value = false;
        }

        private void NotifyDeployed()
        {
            Deployed?.Invoke();
            _onDeployed?.Invoke();
        }
    }
}