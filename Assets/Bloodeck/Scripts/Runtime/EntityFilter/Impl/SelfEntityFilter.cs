using System;

namespace Bloodeck
{
    [Serializable]
    public class SelfEntityFilter : IEntityFilter
    {
        public IEntities Filter(IEntities entities, IEntity instigator = null)
        {
            return new SerializableEntities(instigator);
        }
    }
}