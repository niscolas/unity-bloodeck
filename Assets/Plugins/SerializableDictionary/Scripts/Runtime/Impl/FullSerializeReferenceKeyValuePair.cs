using System;
using UnityEngine;

namespace SerializableDictionary
{
    
    [Serializable]
    public class FullSerializeReferenceKeyValuePair<TKey, TValue> : IKeyValuePair<TKey, TValue>
    {
        [SerializeReference, SubclassSelector]
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