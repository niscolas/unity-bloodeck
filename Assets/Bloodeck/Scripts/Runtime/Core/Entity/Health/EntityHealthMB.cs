using Healthy;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Entity Health")]
    public class EntityHealthMB : BaseEntityComponentMB, IEntityHealth
    {
        [Inject, SerializeField]
        private HealthMB _health;

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

        public int Current
        {
            get => (int) _health.Current;
            set => _health.Current = value;
        }

        public IHealth Health
        {
            get => _health;
            set => _health = value as HealthMB;
        }

        public int Max
        {
            get => (int) _health.Max;
            set => _health.Max = value;
        }

        public int Min
        {
            get => (int) _health.Min;
            set => _health.Min = value;
        }

        [Inject]
        private EntityHealthController _controller;

        public void TakeDamage(int damageValue, IEntity instigator = null)
        {
            _controller.TakeDamage(damageValue, instigator);
        }

        public void Heal(int healValue, IEntity instigator = null)
        {
            _controller.Heal(healValue, instigator);
        }
    }
}