namespace Bloodeck
{
    public class CardAttackProxy : ICardAttack
    {
        public int AttackValue { get; set; }
        
        public ICard Owner { get; }

        private readonly CardAttackController _controller;

        public CardAttackProxy(ICard selfCard, int attackValue = 0)
        {
            _controller = new CardAttackController(this);
            
            AttackValue = attackValue;
            Owner = selfCard;
        }
        
        public void Attack(IEntity target)
        {
            _controller.Attack(target);
        }

        public void Attack(IEntityHealth target)
        {
            _controller.Attack(target);
        }
    }
}