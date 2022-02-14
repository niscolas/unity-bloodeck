using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Entity Attack")]
    public class EntityAttackComponentMB : EntityComponentWithTemplateMB, IEntityAttackComponent
    {
        [Header(HeaderTitles.Output)]
        [SerializeField]
        private FloatReference _attackValueOutput;

        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent<float> _onAttackValueChanged;

        public event Action<float> AttackValueChanged;

        public float AttackValue
        {
            get => _attackValueOutput.Value;
            set => _attackValueOutput.Value = value;
        }

        [Inject]
        private EntityAttackComponentController _controller;

        private void Start()
        {
            _controller.AttackValueChanged += Controller_OnAttackValueChanged;
        }

        private void OnDestroy()
        {
            _controller.AttackValueChanged -= Controller_OnAttackValueChanged;
        }

        public void Attack(IEntity target)
        {
            _controller.Attack(target);
        }

        public void Attack(IEntityHealthComponent target)
        {
            _controller.Attack(target);
        }

        public override void LoadCurrentTemplate()
        {
            _controller.LoadCurrentTemplate();
        }

        public void LoadTemplate(IEntityAttackComponentTemplate template)
        {
            _controller.LoadTemplate(template);
        }

        private void Controller_OnAttackValueChanged(float newValue)
        {
            AttackValueChanged?.Invoke(newValue);
            _onAttackValueChanged?.Invoke(newValue);
        }
    }
}