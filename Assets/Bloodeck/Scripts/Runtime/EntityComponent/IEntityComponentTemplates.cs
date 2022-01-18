using System.Collections.Generic;

namespace Bloodeck
{
    public interface IEntityComponentTemplates :
        ICollection<IEntityComponentTemplate>, ITryGettable<IEntityComponentTemplate> { }
}