using System;

namespace SerializableDictionary
{
    [Serializable]
    public class OnlyKeySerializeReferenceSerializableDictionary<TKey, TValue> :
        SerializableDictionary<TKey, TValue, OnlyKeySerializeReferenceKeyValuePair<TKey, TValue>>
    {
        public OnlyKeySerializeReferenceSerializableDictionary(TKey defaultKey) : base(defaultKey) { }
    }
}