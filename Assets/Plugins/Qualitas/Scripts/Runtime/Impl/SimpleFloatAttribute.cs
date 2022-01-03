using System;

namespace Qualitas
{
    [Serializable]
    public class SimpleFloatAttribute : IAttribute<float>
    {
        public float Value { get; }
    }
}