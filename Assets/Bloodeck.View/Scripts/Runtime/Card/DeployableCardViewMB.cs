using System;
using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Bloodeck.View
{
    public class DeployableCardViewMB : CachedMB
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

        [Required, SerializeField]
        private SlotDetectorMB _slotDetector;

        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent _onDeployed;

        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private CardMB _card;

        [Inject, SerializeField]
        private DeployableCardMB _deployableCard;

        [Header(HeaderTitles.Debug)]
        [SerializeField]
        private BoolReference _isDeploying = new BoolReference();

        [SerializeField]
        private BoolReference _isDeployed = new BoolReference();

        [SerializeField]
        private BoolReference _canBeDeployed = new BoolReference();

        public event Action DeployStarted;
        public event Action Deployed;

        public bool IsDeploying
        {
            get => _isDeploying.Value;
            set => _isDeploying.Value = value;
        }

        public bool IsDeployed
        {
            get => _isDeployed.Value;
            set => _isDeployed.Value = value;
        }

        public bool CanBeDeployed
        {
            get => _canBeDeployed.Value;
            set => _canBeDeployed.Value = value;
        }

        private float DeployedSizeFactor => _deployedSizeFactor.Value;

        public CardSlotMB SelectedSlot => _slotDetector.SelectedSlot;

        public SelectableCardSlotMB SelectableSlot => _slotDetector.SelectableCardSlot;

        [Inject]
        private IUnityTimeService _timeService;

        private Vector3 _initialScale;

        private void OnEnable()
        {
            ResetState();
        }

        private void Start()
        {
            _initialScale = Vector3.one;
        }

        private void Update()
        {
            if (IsDeployed)
            {
                return;
            }

            if (!IsDeploying)
            {
                if (!CanBeDeployed)
                {
                    _slotDetector.ResetSelectedCardSlot();
                    return;
                }

                HandleScaling();
            }
            else
            {
                if (CheckReachedSlot())
                {
                    OnDeployed();
                    return;
                }

                MoveTowardsSlot();
            }
        }

        public void BeginDeploy()
        {
            DeployStarted?.Invoke();
            IsDeploying = true;
            _slotDetector.enabled = false;
            SelectableSlot.Deselect();
        }

        public void ResetState()
        {
            IsDeploying = false;
            IsDeployed = false;
            _slotDetector.enabled = true;
        }

        private void HandleScaling()
        {
            float t = _timeService.DeltaTime * _hoveringSizeChangeSpeed.Value;

            if (!SelectedSlot)
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

        private bool CheckReachedSlot()
        {
            return Vector3.Distance(
                _transform.position,
                SelectedSlot.transform.position) < _maxDistanceFromSlot.Value;
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
                SelectedSlot.transform.position,
                t);
        }

        private void OnDeployed()
        {
            _slotDetector.enabled = false;
            _slotDetector.ResetData();
            IsDeployed = true;
            IsDeploying = false;
            NotifyDeployed();
        }

        private void NotifyDeployed()
        {
            Deployed?.Invoke();
            _onDeployed?.Invoke();
        }
    }
}