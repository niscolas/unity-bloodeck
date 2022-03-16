using System;
using System.Collections.Generic;
using niscolas.UnityUtils.Core.Extensions;
using niscolas.UnityUtils.SerializeReference;

namespace Bloodeck
{
    [Serializable]
    public class SerializableEntityFilters : SerializeReferenceCollection<IEntityFilter>, IEntityFilters
    {
        public IEnumerable<IEntity> Filter(IEnumerable<IEntity> entities, IEntity instigator = null)
        {
            this.ForEach(x => { entities = x.Filter(entities, instigator); });
            return entities;
        }
    }
}