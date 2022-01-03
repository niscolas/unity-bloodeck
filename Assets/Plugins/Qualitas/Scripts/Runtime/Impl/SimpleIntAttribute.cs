using System;
using UnityEngine;

namespace Qualitas
{
    [Serializable]
    public class SimpleIntAttribute : IAttribute<int>
    {
        [SerializeField]
        private int _value;
        
        public int Value { get; }
    }
}