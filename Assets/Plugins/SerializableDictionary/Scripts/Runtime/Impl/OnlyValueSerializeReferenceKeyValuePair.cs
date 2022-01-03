using System;
using UnityEngine;

namespace SerializableDictionary
{
    
    [Serializable]
    public class OnlyValueSerializeReferenceKeyValuePair<TKey, TValue> : IKeyValuePair<TKey, TValue>
    {
        [SerializeField]
        private TKey _key;

        [SerializeReference, SubclassSelector]
        private TValue _value;

        public TKey Key
        {
            get => _key;
            set => _key = value;
        }

        public TValue Value
        {
            get => _value;
            set => _value = value;
        }
    }
}