using System;
using System.Collections.Generic;
using System.Linq;
using niscolas.UnityUtils.Core.Extensions;

namespace Bloodeck
{
    [Serializable]
    public class DestroyEntityCardEffectSystem : ICardEffectSystem
    {
        public void Apply(IEnumerable<IEntity> targets, ICard instigator = null)
        {
            targets.ToArray().ForEach(x => Apply(x, instigator));
        }

        public void Apply(IEntity target, ICard instigator)
        {
            target.Destroy(instigator.SelfEntity);
        }
    }
}