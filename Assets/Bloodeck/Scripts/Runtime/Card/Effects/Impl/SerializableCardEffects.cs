using System;
using System.Collections.Generic;
using niscolas.UnityUtils.Core.Extensions;
using niscolas.UnityUtils.SerializeReference;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public class SerializableCardEffects : SerializeReferenceCollection<ICardEffectSystem>, ICardEffects
    {
        [SerializeReference, SubclassSelector]
        private IEntityFilters _targetFilters;

        public IEntityFilters TargetFilters => _targetFilters;

        public void Trigger(IEnumerable<IEntity> rawTargets, ICard card)
        {
            IEnumerable<IEntity> filteredTargets = _targetFilters.Filter(rawTargets, card.SelfEntity);
            this.ForEach(x => x.Apply(filteredTargets, card));
        }
    }
}