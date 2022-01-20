using System;
using System.Collections.Generic;
using UnityEngine;

namespace SerializableDictionary
{
    [Serializable]
    public abstract class SerializableDictionary<TKey, TValue, TKeyValuePair> :
        Dictionary<TKey, TValue>,
        ISerializationCallbackReceiver
        where TKeyValuePair : IKeyValuePair<TKey, TValue>, new()
    {
        [SerializeField]
        private List<TKeyValuePair> _listContent = new List<TKeyValuePair>();

        [SerializeField, HideInInspector]
        private bool _keyCollision;

        private TKey _defaultKey;

        protected SerializableDictionary(TKey defaultKey)
        {
            _defaultKey = defaultKey;
        }

        public void OnAfterDeserialize()
        {
            Clear();
            _keyCollision = false;

            for (int i = 0; i < _listContent.Count; i++)
            {
                TKey key = _listContent[i].Key;

                if (key != null && !ContainsKey(key))
                {
                    Add(_listContent[i].Key, _listContent[i].Value);
                }
                else if (!ContainsKey(_defaultKey))
                {
                    Add(_defaultKey, _listContent[i].Value);
                }
            }
        }

        public void OnBeforeSerialize()
        {
            _listContent.Clear();
            foreach (KeyValuePair<TKey, TValue> keyValuePair in this)
            {
                _listContent.Add(new TKeyValuePair
                {
                    Key = keyValuePair.Key,
                    Value = keyValuePair.Value
                });
            }
        }
    }
}