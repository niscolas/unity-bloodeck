using System;
using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Attack")]
    public class CardAttackMB : CardComponentMB, ICardAttack
    {
        [Header(HeaderTitles.Output)]
        [SerializeField]
        private FloatReference _attackValueOutput;

        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent<float> _onAttackValueChanged;

        public event Action<float> AttackValueChanged;

        public float AttackValue { get; set; }

        [Inject]
        private CardAttackController _controller;

        protected override void Awake()
        {
            _controller.AttackValueChanged += Controller_OnAttackValueChanged;
        }

        private void Start()
        {
            LoadTemplate();
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

        private void Controller_OnAttackValueChanged(float newValue)
        {
            _attackValueOutput.Value = newValue;
            AttackValueChanged?.Invoke(newValue);
            _onAttackValueChanged?.Invoke(newValue);
        }

        private bool TryGetTemplate(out ICardAttackTemplate cardAttack)
        {
            return _owner.Template.ComponentTemplates.TryGet(out cardAttack);
        }
        

        private void LoadTemplate()
        {
            if (!TryGetTemplate(out ICardAttackTemplate template))
            {
                return;
            }

            _controller.AttackValue = template.AttackValue;
        }
    }
}