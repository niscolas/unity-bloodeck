using System;

namespace Bloodeck
{
    [Serializable]
    public class AllEntityFilter : IEntityFilter
    {
        public IEntities Filter(IEntities entities, IEntity instigator = null)
        {
            return entities;
        }
    }
}