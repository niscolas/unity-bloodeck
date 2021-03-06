using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public struct SerializableEntityAttackComponentTemplate : IEntityAttackComponentTemplate
    {
        [SerializeField]
        private FloatReference _attackValue;

        [SerializeField]
        private IntReference _attacksPerTurn;

        [SerializeReference, SubclassSelector]
        private IEntityFilters _targetFilters;

        public float AttackValue => _attackValue.Value;

        public int AttacksPerTurn => _attacksPerTurn.Value;

        public IEntityFilters TargetFilters => _targetFilters;
    }
}