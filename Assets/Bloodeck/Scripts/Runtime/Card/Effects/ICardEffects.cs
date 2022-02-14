using System.Collections.Generic;

namespace Bloodeck
{
    public interface ICardEffects : ICollection<ICardEffectSystem>
    {
        IEntityFilters TargetFilters { get; }
        void Trigger(IEntities rawTargets, ICard card);
    }
}