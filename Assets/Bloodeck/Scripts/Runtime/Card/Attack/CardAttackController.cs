namespace Bloodeck
{
    public class CardAttackController : ICardAttack
    {
        private IEntity SelfEntity => _humbleObject.SelfCard?.SelfEntity;

        public int AttackValue
        {
            get => _humbleObject.AttackValue;
            set => _humbleObject.AttackValue = value;
        }

        public ICard SelfCard => _humbleObject.SelfCard;

        private readonly ICardAttack _humbleObject;

        public CardAttackController(ICardAttack humbleObject)
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