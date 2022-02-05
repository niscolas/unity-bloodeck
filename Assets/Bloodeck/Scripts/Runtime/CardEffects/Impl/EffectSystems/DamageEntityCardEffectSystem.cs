using System;
using System.Collections.Generic;

namespace Bloodeck
{
    [Serializable]
    public class DamageEntityCardEffectSystem : ICardEffectSystem
    {
        public void Apply(IEnumerable<IEntity> targets, ICard instigator) { }
    }
}