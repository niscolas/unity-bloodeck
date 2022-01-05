using Healthy;

namespace Bloodeck
{
    public interface IEntityHealth : IEntityComponent
    {
        bool CanHeal { get; set; }
        
        bool CanTakeDamage { get; set; }
        
        int Current { get; set; }

        IHealth Health { get; }

        int Max { get; set; }

        int Min { get; set; }
        
        void Heal(int healValue, IEntity instigator = null);

        void TakeDamage(int damageValue, IEntity instigator = null);
    }
}