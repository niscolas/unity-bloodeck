using System;
using UnityEngine;

namespace Qualitas
{
    [Serializable]
    public struct NamedAttributeType : IAttributeType
    {
        [SerializeField]
        private string _name;

        public string Name => _name;

        public NamedAttributeType(string name)
        {
            _name = name;
        }

        public static implicit operator string(NamedAttributeType namedAttributeType)
        {
            return namedAttributeType.Name;
        }

        public static implicit operator NamedAttributeType(string name)
        {
            return new NamedAttributeType(name);
        }

        public override bool Equals(object obj)
        {
            if (obj is NamedAttributeType nameableAttributeType)
            {
                return Name == nameableAttributeType.Name;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}