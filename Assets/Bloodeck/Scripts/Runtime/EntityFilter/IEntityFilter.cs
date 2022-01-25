using System.Collections.Generic;

namespace Bloodeck
{
    public interface IEntityFilter
    {
        IEnumerable<IEntityFilter> Filter(IEnumerable<IEntityFilter> entities);
    }
}