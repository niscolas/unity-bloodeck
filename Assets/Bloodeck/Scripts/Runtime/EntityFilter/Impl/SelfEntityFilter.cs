using System;
using System.Collections.Generic;

namespace Bloodeck
{
    [Serializable]
    public class SelfEntityFilter : IEntityFilter
    {
        public IEnumerable<IEntity> Filter(IEnumerable<IEntity> entities, IEntity instigator = null)
        {
            yield return instigator;
        }
    }
}