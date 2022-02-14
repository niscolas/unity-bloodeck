using System;
using Healthy;
using Zenject;

namespace Bloodeck
{
    public class EntityHealthComponentController : IEntityHealthComponent, IHealth
    {
        public event Action<float> DamageTaken;
        public event Action<(float, float)> DamageTakenWithHistory;
        public event Action Died;
        public event Action<float> Healed;
        public event Action<(float, float)> HealedWithHistory;
        public event Action Revived;
        public event Action<float> ValueChanged;
        public event Action<(float, float)> ValueChangedWithHistory;

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

        public IEntity OwnerEntity => _humbleObject.OwnerEntity;

        public const string DisplayName = EntityHealthComponentMB.DisplayName + " Controller";

        private readonly IEntityHealthComponent _asIEntityHealthComponent;
        private readonly IHealth _asIHealth;
        private readonly IEntityHealthComponentData _humbleObject;

        [Inject]
        private IHealth _healthController;

        public EntityHealthComponentController(IEntityHealthComponentData humbleObject)
        {
            _humbleObject = humbleObject;
            _asIEntityHealthComponent = this;
            _asIHealth = this;
        }

        [Inject]
        private void Init(IHealth healthController)
        {
            _healthController = healthController;

            _healthController.DamageTaken +=
                healthValue => DamageTaken?.Invoke(healthValue);

            _healthController.DamageTakenWithHistory +=
                healthHistory => DamageTakenWithHistory?.Invoke(healthHistory);

            _healthController.Died +=
                () => Died?.Invoke();

            _healthController.Healed +=
                healthValue => Healed?.Invoke(healthValue);

            _healthController.HealedWithHistory +=
                healthHistory => HealedWithHistory?.Invoke(healthHistory);

            _healthController.Revived +=
                () => Revived?.Invoke();

            _healthController.ValueChanged +=
                healthValue => ValueChanged?.Invoke(healthValue);

            _healthController.ValueChangedWithHistory +=
                healthHistory => ValueChangedWithHistory?.Invoke(healthHistory);
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

        public void LoadTemplate(IEntityHealthTemplate template)
        {
            Max = template.Max;
            Current = Max;
        }

        public void LoadCurrentTemplate()
        {
            this.TryLoadCurrentTemplate<IEntityHealthTemplate, IEntityHealthComponent>();
        }
    }
}