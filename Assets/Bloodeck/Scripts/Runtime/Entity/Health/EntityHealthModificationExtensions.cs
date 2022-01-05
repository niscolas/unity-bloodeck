namespace Bloodeck
{
    public static class EntityHealthModificationExtensions
    {
        public static IEntityHealth WithCurrent(this IEntityHealth entityHealth, int value)
        {
            entityHealth.Current = value;
            return entityHealth;
        }
        
        public static IEntityHealth WithMax(this IEntityHealth entityHealth, int value)
        {
            entityHealth.Max = value;
            return entityHealth;
        }
        
        public static IEntityHealth WithMin(this IEntityHealth entityHealth, int value)
        {
            entityHealth.Min = value;
            return entityHealth;
        }
    }
}