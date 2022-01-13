using System;

namespace Bloodeck
{
    public class CardAttackController : ICardAttack
    {
        public event Action<int> AttackValueChanged;

        public int AttackValue
        {
            get => _humbleObject.AttackValue;
            set
            {
                _humbleObject.AttackValue = value;
                AttackValueChanged?.Invoke(value);
            }
        }

        public ICard Owner => _humbleObject.Owner;

        private IEntity SelfEntity => _humbleObject.Owner?.SelfEntity;

        private readonly ICardAttackData _humbleObject;

        public CardAttackController(ICardAttackData humbleObject)
        {
            _humbleObject = humbleObject;
        }

        public void Attack(IEntity target)
        {
            if (!target.Components.TryGet(out IEntityHealth entityHealth))
            {
                return;
            }

            Attack(entityHealth);
        }

        public void Attack(IEntityHealth target)
        {
            target.TakeDamage(AttackValue, SelfEntity);
        }
    }
}