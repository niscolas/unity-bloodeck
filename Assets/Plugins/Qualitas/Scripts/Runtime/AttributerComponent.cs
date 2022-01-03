using niscolas.UnityUtils.Core;

namespace Qualitas
{
    public class AttributerComponent : CachedMonoBehaviour, IAttributer
    {
        public IAttributes Attributes { get; }
    }
}