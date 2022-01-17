using System;
using Healthy;
using Zenject;

namespace Bloodeck
{
    public class EntityHealthProxy : IEntityHealth, IHealth
    {
        public bool CanHeal { get; set; } = true;

        public bool CanTakeDamage { get; set; } = true;

        float IHealthData.Current
        {
            get => Current;
            set => Current = EntityHealthController.FormatHealthValue(value);
        }

        public float Current { get; set; }

        [Inject]
        public IHealth Health { get; private set; }

        float IHealthData.Max
        {
            get => Max;
            set => Max = EntityHealthController.FormatHealthValue(value);
        }

        public float Max { get; set; }

        float IHealthData.Min
        {
            get => Min;
            set => Min = EntityHealthController.FormatHealthValue(value);
        }

        public float Min { get; set; }

        public IEntity Owner { get; }

        private readonly EntityHealthController _controller;

        public EntityHealthProxy(
            IEntity owner,
            int current = 0,
            int max = 0,
            int min = default)
        {
            _controller = new EntityHealthController(this);

            Owner = owner;
            Current = current;
            Max = max;
            Min = min;
        }

        public void Heal(
            float healValue,
            object instigator = null,
            Action<(float, float)> healedWithHistoryCallback = null,
            Action revivedCallback = null)
        {
            _controller.Heal(healValue, instigator, healedWithHistoryCallback, revivedCallback);
        }

        public void Heal(float healValue, IEntity instigator = null)
        {
            _controller.Heal(healValue, instigator);
        }

        public void TakeDamage(
            float damageValue,
            object instigator = null,
            Action<(float, float)> damageTakenWithHistoryCallback = null,
            Action deathCallback = null)
        {
            _controller.TakeDamage(damageValue, instigator, damageTakenWithHistoryCallback, deathCallback);
        }

        public void TakeDamage(float damageValue, IEntity instigator = null)
        {
            _controller.TakeDamage(damageValue, instigator);
        }
    }
}