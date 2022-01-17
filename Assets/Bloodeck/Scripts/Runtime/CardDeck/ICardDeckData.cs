using System.Collections.Generic;

namespace Bloodeck
{
    public interface ICardDeckData : ICollection<ICardTemplate>
    {
        string Name { get; }
    }
}