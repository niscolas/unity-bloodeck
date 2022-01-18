namespace Bloodeck
{
    public interface IEntityHealth : IEntityHealthData
    {
        void Heal(float healValue, IEntity instigator = null);

        void TakeDamage(float damageValue, IEntity instigator = null);
    }
}