namespace Bloodeck
{
    public class CardAttackData : ICardAttackData
    {
        public int AttackValue { get; set; }

        public ICard Owner { get; }

        public CardAttackData(ICard owner, int attackValue = default)
        {
            Owner = owner;
            AttackValue = attackValue;
        }
    }
}