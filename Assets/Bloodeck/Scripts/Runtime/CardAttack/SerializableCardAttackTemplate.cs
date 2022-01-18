using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public struct SerializableCardAttackTemplate : ICardAttackTemplate
    {
        [SerializeField]
        private FloatReference _attackValue;

        public float AttackValue => _attackValue.Value;
    }
}