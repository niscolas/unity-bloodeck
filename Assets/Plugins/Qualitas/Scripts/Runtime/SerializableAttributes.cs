using System;
using SerializableDictionary;
using UnityEngine;

namespace Qualitas
{
    [Serializable]
    public class SerializableAttributes : IAttributes
    {
        [SerializeField]
        private FullSerializeReferenceSerializableDictionary<IAttributeType, IAttribute> _realContent =
            new FullSerializeReferenceSerializableDictionary<IAttributeType, IAttribute>(new NamedAttributeType("default"));

        // public SerializableAttributes()
        // {
        //     _content = new SerializableDictionary<IAttributeType, IAttribute>();
        // }

        public bool Add(IAttributeType type, IAttribute attribute)
        {
            return default;// _content.TryAdd(type, attribute);
        }

        public bool TryGet(IAttributeType type, out IAttribute attribute)
        {
            attribute = null;
            return true;// _content.TryAdd(type, attribute);
        }
    }
}