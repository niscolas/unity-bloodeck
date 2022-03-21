using System;
using Healthy;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + DisplayName)]
    public class EntityHealthComponentMB : EntityComponentWithTemplateMB, IEntityHealthComponent
    {
        [SerializeField]
        private FloatReference _current;

        [SerializeField]
        private FloatReference _max;

        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private HealthMB _health;

        public event Action<object> Attacked;
        public event Action<float> DamageTaken;
        public event Action Died;
        public event Action<float> ValueChanged;

        public bool CanHeal
        {
            get => _health.CanHeal;
            set => _health.CanHeal = value;
        }

        public bool CanTakeDamage
        {
            get => _health.CanTakeDamage;
            set => _health.CanTakeDamage = value;
        }

        public float Current
        {
            get => _health.Current;
            set => _health.Current = value;
        }

        public float Max
        {
            get => _health.Max;
            set
            {
                _health.Max = value;
                OnMaxHealthChanged();
            }
        }

        public float Min
        {
            get => _health.Min;
            set => _health.Min = value;
        }

        public const string DisplayName = "Entity Health";

        [Inject]
        private EntityHealthComponentController _controller;

        private void Start()
        {
            _controller.Attacked += OnAttacked;
            _controller.DamageTaken += OnDamageTaken;
            _controller.Died += OnDied;
            _controller.ValueChanged += OnValueChanged;
        }

        private void OnDestroy()
        {
            _controller.Attacked -= OnAttacked;
            _controller.DamageTaken -= OnDamageTaken;
            _controller.Died -= OnDied;
            _controller.ValueChanged -= OnValueChanged;
        }

        public void TakeDamage(float damageValue, IEntity instigator = null)
        {
            _controller.TakeDamage(damageValue, instigator);
        }

        public void Heal(float healValue, IEntity instigator = null)
        {
            _controller.Heal(healValue, instigator);
        }

        public void LoadTemplate(IEntityHealthTemplate template)
        {
            _controller.LoadTemplate(template);
        }

        public override void LoadCurrentTemplate()
        {
            _controller.LoadCurrentTemplate();
        }

        private void OnValueChanged(float value)
        {
            _current.Value = value;
            ValueChanged?.Invoke(value);
        }

        private void OnAttacked(object instigator)
        {
            Attacked?.Invoke(instigator);
        }

        private void OnDamageTaken(float value)
        {
            DamageTaken?.Invoke(value);
        }

        private void OnDied()
        {
            Died?.Invoke();
        }

        private void OnMaxHealthChanged()
        {
            _max.Value = Max;
        }
    }
}