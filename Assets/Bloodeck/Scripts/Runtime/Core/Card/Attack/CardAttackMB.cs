using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Attack")]
    public class CardAttackMB : BaseCardComponentMB, ICardAttack
    {
        [Header(HeaderTitles.Output)]
        [SerializeField]
        private IntReference _attackValueOutput;

        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent<int> _onAttackValueChanged;

        public event Action<int> AttackValueChanged;

        public int AttackValue { get; set; }

        [Inject]
        private CardAttackController _controller;

        protected override void Awake()
        {
            _controller.AttackValueChanged += Controller_OnAttackValueChanged;
        }

        private void Start()
        {
            _controller.AttackValue = _owner.Template.AttackValue;
        }

        private void OnDestroy()
        {
            _controller.AttackValueChanged -= Controller_OnAttackValueChanged;
        }

        public void Attack(IEntity target)
        {
            _controller.Attack(target);
        }

        public void Attack(IEntityHealth target)
        {
            _controller.Attack(target);
        }

        private void Controller_OnAttackValueChanged(int newValue)
        {
            _attackValueOutput.Value = newValue;
            AttackValueChanged?.Invoke(newValue);
            _onAttackValueChanged?.Invoke(newValue);
        }
    }
}