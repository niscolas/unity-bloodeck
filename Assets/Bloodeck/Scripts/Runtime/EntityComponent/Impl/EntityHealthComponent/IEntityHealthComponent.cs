namespace Bloodeck
{
    public interface IEntityHealthComponent : IEntityHealthComponentData
    {
        void Heal(float healValue, IEntity instigator = null);

        void TakeDamage(float damageValue, IEntity instigator = null);
    }
}