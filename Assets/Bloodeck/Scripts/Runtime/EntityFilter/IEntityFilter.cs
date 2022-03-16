using System.Collections.Generic;

namespace Bloodeck
{
    public interface IEntityFilter
    {
        IEnumerable<IEntity> Filter(IEnumerable<IEntity> entities, IEntity instigator = null);
    }
}