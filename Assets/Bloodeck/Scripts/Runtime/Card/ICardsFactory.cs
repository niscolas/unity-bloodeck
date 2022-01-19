using System.Collections.Generic;

namespace Bloodeck
{
    public interface ICardsFactory
    {
        ICards Create();

        ICards Create(IEnumerable<ICard> content);
    }
}