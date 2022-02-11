using System;
using System.Collections.Generic;
using niscolas.UnityUtils.SerializeReference;

namespace Bloodeck
{
    [Serializable]
    public class SerializableEntities : SerializeReferenceCollection<IEntity>, IEntities
    {
        public SerializableEntities() { }
        public SerializableEntities(IEnumerable<IEntity> content) : base(content) { }
        public SerializableEntities(params IEntity[] content) : base(content) { }
    }
}