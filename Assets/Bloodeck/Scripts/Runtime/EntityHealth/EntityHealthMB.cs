using Healthy;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Entity Health")]
    public class EntityHealthMB : EntityComponentMB, IEntityHealth
    {
        [Inject, SerializeField]
        private HealthMB _health;

        [SerializeField]
        private FloatReference _current;

        [SerializeField]
        private FloatReference _max;

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
            set => _health.Max = value;
        }

        public float Min
        {
            get => _health.Min;
            set => _health.Min = value;
        }

        [Inject]
        private EntityHealthController _controller;

        private void Start()
        {
            LoadTemplate();
        }

        public void TakeDamage(float damageValue, IEntity instigator = null)
        {
            _controller.TakeDamage(damageValue, instigator);
        }

        public void Heal(float healValue, IEntity instigator = null)
        {
            _controller.Heal(healValue, instigator);
        }

        private void LoadTemplate()
        {
            if (!TryGetTemplate(out IEntityHealthTemplate entityHealth))
            {
                return;
            }

            _max.Value = entityHealth.Max;
            _current.Value = _max.Value;
        }

        private bool TryGetTemplate(out IEntityHealthTemplate entityHealth)
        {
            return _owner.LoadedTemplate.ComponentTemplates.TryGet(out entityHealth);
        }
    }
}