using System;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public class SerializableCardEffect : ICardEffect
    {
        [SerializeReference, SubclassSelector]
        private IEntityFilters _targetFilters;

        [SerializeReference, SubclassSelector]
        private ICardEffectSystem _system;

        public IEntityFilters TargetFilters => _targetFilters;

        public ICardEffectSystem System => _system;
    }
}