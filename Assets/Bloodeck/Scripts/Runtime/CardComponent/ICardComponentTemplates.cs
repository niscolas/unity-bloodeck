using System.Collections.Generic;

namespace Bloodeck
{
    public interface ICardComponentTemplates :
        ICollection<ICardComponentTemplate>, ITryGettable<ICardComponentTemplate> { }
}