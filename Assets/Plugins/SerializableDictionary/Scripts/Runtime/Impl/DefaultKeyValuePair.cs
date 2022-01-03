using System;
using UnityEngine;

namespace SerializableDictionary
{
    [Serializable]
    public struct DefaultKeyValuePair<TKey, TValue>: IKeyValuePair<TKey, TValue>
    {
        [SerializeField]
        private TKey _key;
        
        [SerializeField]
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

        public DefaultKeyValuePair(TKey key, TValue value)
        {
            _key = key;
            _value = value;
        }
    }
}