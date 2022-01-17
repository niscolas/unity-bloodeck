namespace Bloodeck
{
    public static class EntityHealthExtensions
    {
        public static IEntityHealth WhichCanHeal(this IEntityHealth self, bool value = true)
        {
            self.CanHeal = value;
            return self;
        }

        public static IEntityHealth WhichCanTakeDamage(this IEntityHealth self, bool value = true)
        {
            self.CanTakeDamage = value;
            return self;
        }

        public static IEntityHealth WithCurrent(this IEntityHealth self, int value)
        {
            self.Current = value;
            return self;
        }

        public static IEntityHealth WithMax(this IEntityHealth self, int value)
        {
            self.Max = value;
            return self;
        }

        public static IEntityHealth WithMin(this IEntityHealth self, int value)
        {
            self.Min = value;
            return self;
        }
    }
}