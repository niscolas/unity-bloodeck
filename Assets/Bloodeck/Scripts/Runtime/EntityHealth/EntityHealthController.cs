using System;
using Healthy;
using Zenject;

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

        public float Current
        {
            get => _humbleObject.Current;
            set => _humbleObject.Current = FormatHealthValue(value);
        }

        public float Max
        {
            get => _humbleObject.Max;
            set => _humbleObject.Max = FormatHealthValue(value);
        }

        public float Min
        {
            get => _humbleObject.Min;
            set => _humbleObject.Min = FormatHealthValue(value);
        }

        public IEntity Owner => _humbleObject.Owner;

        private readonly IEntityHealth _asIEntityHealth;

        private readonly IHealth _asIHealth;

        private readonly IEntityHealthData _humbleObject;

        [Inject]
        private IHealth _healthController;

        public EntityHealthController(IEntityHealthData humbleObject)
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
            _healthController.Heal(
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
            _healthController.TakeDamage(
                damageValue, instigator, damageTakenWithHistoryCallback, deathCallback);
        }

        public void TakeDamage(float damageValue, IEntity instigator = null)
        {
            _asIHealth.TakeDamage(damageValue, instigator);
        }
    }
}