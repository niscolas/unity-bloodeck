namespace Bloodeck
{
    public class CardAttackData : ICardAttackData
    {
        public float AttackValue { get; set; }

        public ICard Owner { get; }

        public CardAttackData(ICard owner, float attackValue = default)
        {
            Owner = owner;
            AttackValue = attackValue;
        }
    }
}