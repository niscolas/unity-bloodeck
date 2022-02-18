using System;
using DG.Tweening;
using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Bloodeck.View
{
    public class EntityAttackViewMB : CachedMB
    {
        [SerializeField]
        private FloatReference _attackTweenDuration = new FloatReference(0.6f);

        [SerializeField]
        private Ease _attackingEase;

        [SerializeField]
        private FloatReference _repositioningDuration = new FloatReference(1);

        [SerializeField]
        private Ease _repositioningEase;

        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent<EntityMB> _onAttacked;

        [SerializeField]
        private UnityEvent _onInitialPositionReached;

        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private EntityMB _entity;

        public event Action<EntityMB> Attacked;
        public event Action InitialPositionReached;

        public void Attack(EntityMB target)
        {
            Vector3 initialPos = _transform.position;
            _transform
                .DOMove(target.transform.position, _attackTweenDuration.Value)
                .SetEase(_attackingEase)
                .OnComplete(() => OnAttackReachedTarget(target, initialPos));
        }

        public void OnAttacked(EntityMB instigator = null)
        {
            NotifyAttacked(instigator);
        }

        private void CallOnAttackedOnTarget(EntityMB target)
        {
            EntityAttackViewMB entityAttackView = target.GetComponentInChildren<EntityAttackViewMB>();
            if (!entityAttackView)
            {
                return;
            }

            entityAttackView.OnAttacked(_entity);
        }

        private void MoveBackToInitialPosition(Vector3 initialPos)
        {
            _transform
                .DOMove(initialPos, _repositioningDuration.Value)
                .SetEase(_repositioningEase)
                .OnComplete(OnInitialPositionReached);
        }

        private void OnAttackReachedTarget(EntityMB target, Vector3 initialPos)
        {
            CallOnAttackedOnTarget(target);
            MoveBackToInitialPosition(initialPos);
        }

        private void OnInitialPositionReached()
        {
            NotifyInitialPositionReached();
        }

        private void NotifyAttacked(EntityMB instigator = default)
        {
            Attacked?.Invoke(instigator);
            _onAttacked?.Invoke(instigator);
        }

        private void NotifyInitialPositionReached()
        {
            InitialPositionReached?.Invoke();
            _onInitialPositionReached?.Invoke();
        }
    }
}