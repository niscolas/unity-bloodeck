using System.Collections.Generic;

namespace Bloodeck
{
    public interface ICardSlotRestrictions : ICollection<ICardSlotRestriction>
    {
        bool Validate(ICard card);
    }
}