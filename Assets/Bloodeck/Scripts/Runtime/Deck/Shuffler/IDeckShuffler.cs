using System.Collections.Generic;

namespace Bloodeck
{
    public interface IDeckShuffler
    {
        void Shuffle(IList<ICard> cards);
    }
}