using System.Collections.Generic;

namespace Bloodeck
{
    public interface IEntityFilters : ICollection<IEntityFilter>
    {
        IEntities Filter(IEntities entities, IEntity instigator = null);
    }
}