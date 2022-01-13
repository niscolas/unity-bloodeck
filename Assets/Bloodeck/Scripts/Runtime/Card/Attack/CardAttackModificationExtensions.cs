namespace Bloodeck
{
    public static class CardAttackModificationExtensions
    {
        public static ICardAttack WithAttackValue(this ICardAttack cardAttack, int value)
        {
            cardAttack.AttackValue = value;
            return cardAttack;
        }
    }
}