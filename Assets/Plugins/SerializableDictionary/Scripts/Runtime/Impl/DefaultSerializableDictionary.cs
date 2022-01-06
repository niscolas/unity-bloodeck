﻿namespace SerializableDictionary
{
    public class
        DefaultSerializableDictionary<TKey, TValue> :
            SerializableDictionary<TKey, TValue, DefaultKeyValuePair<TKey, TValue>>
    {
        public DefaultSerializableDictionary(TKey defaultKey) : base(defaultKey) { }
    }
}