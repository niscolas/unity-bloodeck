namespace Bloodeck
{
    public static class EntityAttackComponentExtensions
    {
        public static IEntityAttackComponent WithAttackValue(this IEntityAttackComponent self, int value)
        {
            self.AttackValue = value;
            return self;
        }
    }
}