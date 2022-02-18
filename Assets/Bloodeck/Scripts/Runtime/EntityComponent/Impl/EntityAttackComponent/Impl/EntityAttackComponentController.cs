using System;

namespace Bloodeck
{
    public class EntityAttackComponentController : IEntityAttackComponent
    {
        public event Action<IEntity> AttackTriggered;
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

        public int AttacksPerTurn => _humbleObject.AttacksPerTurn;

        public int AttacksLeftInTurn => _humbleObject.AttacksLeftInTurn;

        public IEntity OwnerEntity => _humbleObject.OwnerEntity;

        private readonly IEntityAttackComponentHumbleObject _humbleObject;

        public EntityAttackComponentController(IEntityAttackComponentHumbleObject humbleObject)
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
            if (!CheckCanAttack())
            {
                return;
            }

            target.TakeDamage(AttackValue, OwnerEntity);
            SetAttacksLeftInTurn(AttacksLeftInTurn - 1);
            NotifyAttackTriggered(target);
        }

        public bool CheckCanAttack()
        {
            return AttacksLeftInTurn > 0;
        }

        public void LoadTemplate(IEntityAttackComponentTemplate template)
        {
            AttackValue = template.AttackValue;
            SetAttacksPerTurn(template.AttacksPerTurn);
        }

        public void LoadCurrentTemplate()
        {
            this.TryLoadCurrentTemplate<IEntityAttackComponentTemplate, IEntityAttackComponent>();
        }

        public void OnTurnStarted()
        {
            SetAttacksLeftInTurn(AttacksPerTurn);
        }

        private void SetAttacksPerTurn(int value)
        {
            _humbleObject.SetAttacksPerTurn(value);
        }

        private void SetAttacksLeftInTurn(int value)
        {
            _humbleObject.SetAttacksLeftInTurn(value);
        }

        private void NotifyAttackTriggered(IEntityHealthComponent target)
        {
            AttackTriggered?.Invoke(target.OwnerEntity);
        }
    }
}