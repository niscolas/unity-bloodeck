using System;
using niscolas.UnityUtils.Core.Extensions;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public class HealCardEffectSystem : ICardEffectSystem
    {
        [SerializeField]
        private FloatReference _raw = new FloatReference(1);

        [SerializeField]
        private FloatReference _ratio = new FloatReference(1);

        public void Apply(IEntities targets, ICard instigator)
        {
            targets.ForEach(x => Apply(x, instigator));
        }

        public void Apply(IEntity target, ICard instigator)
        {
            if (!target.Components.TryGet(out IEntityHealthComponent entityHealth))
            {
                return;
            }

            entityHealth.Heal(_raw.Value, instigator.SelfEntity);
            entityHealth.HealRelative(_ratio.Value, instigator.SelfEntity);
        }
    }
}