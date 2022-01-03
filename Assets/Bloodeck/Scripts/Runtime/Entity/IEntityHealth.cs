namespace Bloodeck
{
    public interface IEntityHealth
    {
        void TakeDamage(int value, IEntityAttacker instigator = null);

        void Heal(int value, IEntityAttacker instigator = null);
    }
}