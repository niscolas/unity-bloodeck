using System;
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

        public void Trigger(IEntities rawTargets, ICard card)
        {
            IEntities filteredTargets = _targetFilters.Filter(rawTargets, card.SelfEntity);
            this.ForEach(x => x.Apply(filteredTargets, card));
        }
    }
}