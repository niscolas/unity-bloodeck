using System;
using System.Collections.Generic;
using niscolas.UnityUtils.Core.Extensions;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public class ChangeAttackCardEffectSystem : ICardEffectSystem
    {
        [SerializeField]
        private FloatReference _newAttackValue = new FloatReference(1);

        [SerializeField]
        private BoolReference _relativeChange = new BoolReference(true);

        public void Apply(IEnumerable<IEntity> targets, ICard instigator = null)
        {
            targets.ForEach(x => Apply(x, instigator));
        }

        public void Apply(IEntity target, ICard instigator = null)
        {
            if (!target.Components.TryGet(out IEntityAttackComponent entityAttackComponent))
            {
                return;
            }

            entityAttackComponent.AttackValue = GetNewAttackValue(entityAttackComponent);
        }

        private float GetNewAttackValue(IEntityAttackComponent entityAttackComponent)
        {
            float newAttackValue = _newAttackValue.Value;

            if (_relativeChange.Value)
            {
                newAttackValue += entityAttackComponent.AttackValue;
            }

            return newAttackValue;
        }
    }
}