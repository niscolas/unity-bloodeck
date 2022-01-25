using System;
using niscolas.UnityUtils.Core.Extensions;
using niscolas.UnityUtils.SerializeReference;

namespace Bloodeck
{
    [Serializable]
    public class SerializableCardComponentTemplates :
        SerializeReferenceCollection<ICardComponentTemplate>, ICardComponentTemplates
    {
        public bool TryGet<T>(out T value) where T : ICardComponentTemplate
        {
            return _content.TryGetFirstOfType(out value);
        }
    }
}