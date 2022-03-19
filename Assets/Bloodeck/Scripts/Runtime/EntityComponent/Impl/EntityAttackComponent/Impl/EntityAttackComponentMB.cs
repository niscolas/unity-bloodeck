using System;
using niscolas.UnityUtils.Core.Extensions;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Bloodeck
{
    public class EntityAttackComponentMB :
        EntityComponentWithTemplateMB, IEntityAttackComponent, IEntityAttackComponentHumbleObject
    {
        [Header(HeaderTitles.Output)]
        [SerializeField]
        private FloatReference _attackValueOutput;

        [SerializeField]
        private IntReference _attacksPerTurnOutput;

        [SerializeField]
        private IntReference _attacksLeftInTurn;

        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent<float> _onAttackValueChanged;

        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private MatchMB _match;

        public event Action<IEntity> AttackTriggered;
        public event Action<float> AttackValueChanged;

        public float AttackValue
        {
            get => _attackValueOutput.Value;
            set => _attackValueOutput.Value = value;
        }

        public int AttacksPerTurn => _attacksPerTurnOutput.Value;
        public int AttacksLeftInTurn => _attacksLeftInTurn.Value;

        [Inject]
        private EntityAttackComponentController _controller;

        private void Start()
        {
            if (!_match.CurrentTurn.IsUnityNull())
            {
                Match_OnTurnStarted(_match.CurrentTurn);
            }

            _match.TurnStarted += Match_OnTurnStarted;
            _controller.AttackTriggered += Controller_OnAttackTriggered;
            _controller.AttackValueChanged += Controller_OnAttackValueChanged;
        }

        private void OnDestroy()
        {
            _match.TurnStarted -= Match_OnTurnStarted;
            _controller.AttackTriggered -= Controller_OnAttackTriggered;
            _controller.AttackValueChanged -= Controller_OnAttackValueChanged;
        }

        public bool Attack(IEntity target)
        {
            return _controller.Attack(target);
        }

        public bool Attack(IEntityHealthComponent target)
        {
            return _controller.Attack(target);
        }

        public bool CheckCanAttack()
        {
            return _controller.CheckCanAttack();
        }

        public override void LoadCurrentTemplate()
        {
            _controller.LoadCurrentTemplate();
        }

        public void LoadTemplate(IEntityAttackComponentTemplate template)
        {
            _controller.LoadTemplate(template);
        }

        public void SetAttacksLeftInTurn(int value)
        {
            _attacksLeftInTurn.Value = value;
        }

        public void SetAttacksPerTurn(int value)
        {
            _attacksPerTurnOutput.Value = value;
        }

        private void Controller_OnAttackValueChanged(float newValue)
        {
            AttackValueChanged?.Invoke(newValue);
            _onAttackValueChanged?.Invoke(newValue);
        }

        private void Match_OnTurnStarted(ITurn turn)
        {
            _controller.OnTurnStarted();
        }

        private void Controller_OnAttackTriggered(IEntity target)
        {
            AttackTriggered?.Invoke(target);
        }
    }
}