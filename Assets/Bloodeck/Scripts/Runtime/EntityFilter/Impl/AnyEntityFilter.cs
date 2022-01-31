using System;
using System.Collections.Generic;

namespace Bloodeck
{
    [Serializable]
    public class AnyEntityFilter : IEntityFilter
    {
        public IEnumerable<IEntityFilter> Filter(IEnumerable<IEntityFilter> entities)
        {
            return entities;
        }
    }
}