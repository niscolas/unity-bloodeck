using System.Collections.Generic;

namespace Bloodeck
{
    public interface ICardHandData : IList<ICard>
    {
        int Capacity { get; }
    }
}