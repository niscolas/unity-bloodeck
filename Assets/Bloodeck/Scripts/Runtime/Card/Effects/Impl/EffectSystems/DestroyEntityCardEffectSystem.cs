using System;
using niscolas.UnityUtils.Core.Extensions;

namespace Bloodeck
{
    [Serializable]
    public class DestroyEntityCardEffectSystem : ICardEffectSystem
    {
        public void Apply(IEntities targets, ICard instigator)
        {
            targets.ForEach(x => Apply(x, instigator));
        }

        public void Apply(IEntity target, ICard instigator)
        {
            target.Destroy(instigator.SelfEntity);
        }
    }
}