using System;
using System.Collections.Generic;
using NaughtyAttributes;
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

        [HideIf(nameof(IsMultiplicative))]
        [SerializeField]
        private BoolReference _relativeChange = new BoolReference(true);

        [SerializeField]
        private BoolReference _isMultiplicative = new BoolReference();

        private bool IsMultiplicative => _isMultiplicative.Value;

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

            if (IsMultiplicative)
            {
                newAttackValue *= entityAttackComponent.AttackValue;
            }
            else if (_relativeChange.Value)
            {
                newAttackValue += entityAttackComponent.AttackValue;
            }

            return newAttackValue;
        }
    }
}