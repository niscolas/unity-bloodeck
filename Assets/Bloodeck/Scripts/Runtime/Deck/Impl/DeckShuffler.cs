namespace Bloodeck
{
    public class DeckShuffler : IDeckShuffler
    {
        public void Shuffle(IDeck deck)
        {
            deck.Cards.Shuffle();
        }
    }
}