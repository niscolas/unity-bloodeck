using System;

namespace Bloodeck
{
    public interface IEntityHealthComponentData :
        IEntityComponent, IEntityComponentWithTemplate<IEntityHealthTemplate>
    {
        event Action<float> ValueChanged;
        bool CanHeal { get; set; }

        bool CanTakeDamage { get; set; }

        float Current { get; set; }

        float Max { get; set; }

        float Min { get; set; }
    }
}