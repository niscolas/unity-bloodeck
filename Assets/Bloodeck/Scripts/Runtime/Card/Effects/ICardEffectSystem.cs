using System.Collections.Generic;

namespace Bloodeck
{
    public interface ICardEffectSystem
    {
        void Apply(IEnumerable<IEntity> targets, ICard instigator = null);
        void Apply(IEntity target, ICard instigator = null);
    }
}