using Healthy;

namespace Bloodeck
{
    public interface IEntityHealth : IEntityComponent
    {
        bool CanHeal { get; set; }
        
        bool CanTakeDamage { get; set; }
        
        float Current { get; set; }

        IHealth Health { get; }

        float Max { get; set; }

        float Min { get; set; }
        
        void Heal(float healValue, IEntity instigator = null);

        void TakeDamage(float damageValue, IEntity instigator = null);
    }
}