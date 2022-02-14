using System.Collections.Generic;
using niscolas.UnityUtils.Core.Extensions;

namespace Bloodeck
{
    public class DeckShuffler : IDeckShuffler
    {
        public void Shuffle(IList<ICard> cards)
        {
            cards.Shuffle();
        }
    }
}