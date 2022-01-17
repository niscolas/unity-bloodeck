namespace Bloodeck
{
    public static class CardAttackExtensions
    {
        public static ICardAttack WithAttackValue(this ICardAttack self, int value)
        {
            self.AttackValue = value;
            return self;
        }
    }
}