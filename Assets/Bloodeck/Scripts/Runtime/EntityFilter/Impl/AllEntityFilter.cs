using System;
using System.Collections.Generic;
using System.Linq;

namespace Bloodeck
{
    [Serializable]
    public class AllEntityFilter : IEntityFilter
    {
        public IEnumerable<IEntity> Filter(IEnumerable<IEntity> entities, IEntity instigator = null)
        {
            return entities.Where(x => x.IsActiveInGame);
        }
    }
}