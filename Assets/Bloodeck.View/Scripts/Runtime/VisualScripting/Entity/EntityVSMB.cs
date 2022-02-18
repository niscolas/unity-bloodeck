using System;
using niscolas.UnityUtils.Core;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Bloodeck.View.VisualScripting
{
    public class EntityVSMB : CachedMB
    {
        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private EntityAttackComponentMB _entityAttackComponent;

        [Inject, SerializeField]
        private EntityAttackViewMB _entityAttackView;

        public const string EntityAttackComponent_OnAttackTriggeredCustomEventName =
            nameof(EntityAttackComponent_OnAttackTriggered);

        public const string EntityAttackView_OnInitialPositionReachedCustomEventName =
            nameof(EntityAttackView_OnInitialPositionReached);

        private void OnEnable()
        {
            _entityAttackComponent.AttackTriggered += EntityAttackComponent_OnAttackTriggered;
            _entityAttackView.InitialPositionReached += EntityAttackView_OnInitialPositionReached;
        }

        private void OnDisable()
        {
            _entityAttackComponent.AttackTriggered -= EntityAttackComponent_OnAttackTriggered;
            _entityAttackView.InitialPositionReached -= EntityAttackView_OnInitialPositionReached;
        }

        private void EntityAttackComponent_OnAttackTriggered(IEntity entity)
        {
            CustomEvent.Trigger(
                _gameObject,
                EntityAttackComponent_OnAttackTriggeredCustomEventName,
                (EntityMB) entity);
        }

        private void EntityAttackView_OnInitialPositionReached()
        {
            CustomEvent.Trigger(
                _gameObject,
                EntityAttackView_OnInitialPositionReachedCustomEventName);
        }
    }
}