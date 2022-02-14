using System;

namespace Bloodeck
{
    public class EntityAttackComponentController : IEntityAttackComponent
    {
        public event Action<float> AttackValueChanged;

        public float AttackValue
        {
            get => _humbleObject.AttackValue;
            set
            {
                _humbleObject.AttackValue = value;
                AttackValueChanged?.Invoke(value);
            }
        }

        public IEntity OwnerEntity => _humbleObject.OwnerEntity;

        private readonly IEntityAttackComponentData _humbleObject;

        public EntityAttackComponentController(IEntityAttackComponentData humbleObject)
        {
            _humbleObject = humbleObject;
        }

        public void Attack(IEntity target)
        {
            if (!target.Components.TryGet(out IEntityHealthComponent entityHealth))
            {
                return;
            }

            Attack(entityHealth);
        }

        public void Attack(IEntityHealthComponent target)
        {
            target.TakeDamage(AttackValue, OwnerEntity);
        }

        public void LoadTemplate(IEntityAttackComponentTemplate template)
        {
            AttackValue = template.AttackValue;
        }

        public void LoadCurrentTemplate()
        {
            this.TryLoadCurrentTemplate<IEntityAttackComponentTemplate, IEntityAttackComponent>();
        }
    }
}