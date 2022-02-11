using System;
using niscolas.UnityUtils.Core.Extensions;
using niscolas.UnityUtils.SerializeReference;

namespace Bloodeck
{
    [Serializable]
    public class SerializableEntityFilters : SerializeReferenceCollection<IEntityFilter>, IEntityFilters
    {
        public IEntities Filter(IEntities entities, IEntity instigator = null)
        {
            IEntities result = new SerializableEntities(entities);
            this.ForEach(x => { result = x.Filter(result, instigator); });
            return result;
            
        }
    }
}