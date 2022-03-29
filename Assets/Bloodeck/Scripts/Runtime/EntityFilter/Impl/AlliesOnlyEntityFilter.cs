using System;
using System.Collections.Generic;
using System.Linq;

namespace Bloodeck
{
    [Serializable]
    public class AlliesOnlyEntityFilter : IEntityFilter
    {
        public IEnumerable<IEntity> Filter(IEnumerable<IEntity> entities, IEntity instigator = null)
        {
            IEnumerable<IEntity> result = entities
                .Where(x => 
                    x.IsActiveInGame && instigator.Team == x.Team);
            return result;
        }
    }
}