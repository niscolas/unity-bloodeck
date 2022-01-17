using System;
using Healthy;

namespace Bloodeck
{
    public class EntityHealthController : IEntityHealth, IHealth
    {
        public bool CanHeal
        {
            get => _humbleObject.CanHeal;
            set => _humbleObject.CanHeal = value;
        }

        public bool CanTakeDamage
        {
            get => _humbleObject.CanTakeDamage;
            set => _humbleObject.CanTakeDamage = value;
        }

        float IEntityHealth.Current
        {
            get => _humbleObject.Current;
            set => _humbleObject.Current = value;
        }

        float IHealthData.Current
        {
            get => _asIEntityHealth.Current;
            set => _asIEntityHealth.Current = FormatHealthValue(value);
        }

        public IHealth Health => _humbleObject.Health;

        float IEntityHealth.Max
        {
            get => _humbleObject.Max;
            set => _humbleObject.Max = value;
        }

        float IHealthData.Max
        {
            get => _asIEntityHealth.Max;
            set => _asIEntityHealth.Max = FormatHealthValue(value);
        }

        float IEntityHealth.Min
        {
            get => _humbleObject.Min;
            set => _humbleObject.Min = value;
        }

        float IHealthData.Min
        {
            get => _asIEntityHealth.Min;
            set => _asIEntityHealth.Min = FormatHealthValue(value);
        }

        public IEntity Owner => _humbleObject.Owner;

        private readonly IEntityHealth _asIEntityHealth;

        private readonly IHealth _asIHealth;

        private readonly IEntityHealth _humbleObject;

        public EntityHealthController(IEntityHealth humbleObject)
        {
            _humbleObject = humbleObject;
            _asIEntityHealth = this;
            _asIHealth = this;
        }

        public static int FormatHealthValue(float unformattedHealthValue)
        {
            return (int) unformattedHealthValue;
        }

        public void Heal(
            float healValue,
            object instigator = null,
            Action<(float, float)> healedWithHistoryCallback = null,
            Action revivedCallback = null)
        {
            Health.Heal(
                healValue, instigator, healedWithHistoryCallback, revivedCallback);
        }

        public void Heal(float healValue, IEntity instigator = null)
        {
            _asIHealth.Heal(healValue, instigator);
        }

        public void TakeDamage(
            float damageValue,
            object instigator = null,
            Action<(float, float)> damageTakenWithHistoryCallback = null,
            Action deathCallback = null)
        {
            Health.TakeDamage(
                damageValue, instigator, damageTakenWithHistoryCallback, deathCallback);
        }

        public void TakeDamage(float damageValue, IEntity instigator = null)
        {
            _asIHealth.TakeDamage(damageValue, instigator);
        }
    }
}