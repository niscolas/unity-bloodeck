using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public struct SerializableEntityHealthTemplate : IEntityHealthTemplate
    {
        [SerializeField]
        private FloatReference _max;

        public float Max => _max.Value;
    }
}