using System;

namespace SerializableDictionary
{
    [Serializable]
    public class OnlyValueSerializeReferenceSerializableDictionary<TKey, TValue> :
        SerializableDictionary<TKey, TValue, OnlyValueSerializeReferenceKeyValuePair<TKey, TValue>>
    {
        public OnlyValueSerializeReferenceSerializableDictionary(TKey defaultKey) : base(defaultKey) { }
    }
}