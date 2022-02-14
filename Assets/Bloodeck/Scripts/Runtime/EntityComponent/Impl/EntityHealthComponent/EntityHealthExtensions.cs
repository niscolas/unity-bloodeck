namespace Bloodeck
{
    public static class EntityHealthExtensions
    {
        public static void TakeRelativeDamage(this IEntityHealthComponent self, float ratio, IEntity instigator = null)
        {
            self.TakeDamage(self.Max * ratio, instigator);
        }

        public static void HealRelative(this IEntityHealthComponent self, float ratio, IEntity instigator = null)
        {
            self.Heal(self.Max * ratio, instigator);
        }

        public static IEntityHealthComponent WhichCanHeal(this IEntityHealthComponent self, bool value = true)
        {
            self.CanHeal = value;
            return self;
        }

        public static IEntityHealthComponent WhichCanTakeDamage(this IEntityHealthComponent self, bool value = true)
        {
            self.CanTakeDamage = value;
            return self;
        }

        public static IEntityHealthComponent WithCurrent(this IEntityHealthComponent self, int value)
        {
            self.Current = value;
            return self;
        }

        public static IEntityHealthComponent WithMax(this IEntityHealthComponent self, int value)
        {
            self.Max = value;
            return self;
        }

        public static IEntityHealthComponent WithMin(this IEntityHealthComponent self, int value)
        {
            self.Min = value;
            return self;
        }
    }
}