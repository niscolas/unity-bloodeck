using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using niscolas.UnityUtils.Core.Extensions;
using niscolas.UnityUtils.SerializeReference;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public class SerializableEntityComponentTemplates :
        SerializeReferenceCollection<IEntityComponentTemplate>, IEntityComponentTemplates
    {
        public bool TryGet<T>(out T value) where T : IEntityComponentTemplate
        {
            return _content.TryGetFirstOfType(out value);
        }

        public bool TryGet(Type type, out IEntityComponentTemplate value)
        {
            return _content.TryGetFirstOfType(type, out value);
        }
    }
}