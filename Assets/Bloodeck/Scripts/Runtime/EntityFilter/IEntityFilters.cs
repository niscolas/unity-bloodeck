using System.Collections.Generic;

namespace Bloodeck
{
    public interface IEntityFilters : ICollection<IEntityFilter>
    {
        IEnumerable<IEntity> Filter(
            IEnumerable<IEntity> entities, IEntity instigator = null);
    }
}