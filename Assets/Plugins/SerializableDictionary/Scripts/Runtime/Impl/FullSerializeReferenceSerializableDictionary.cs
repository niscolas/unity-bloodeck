using System;

namespace SerializableDictionary
{
    [Serializable]
    public class FullSerializeReferenceSerializableDictionary<TKey, TValue> :
        SerializableDictionary<TKey, TValue, FullSerializeReferenceKeyValuePair<TKey, TValue>>
    {
        public FullSerializeReferenceSerializableDictionary(TKey defaultKey) : base(defaultKey) { }
    }
}