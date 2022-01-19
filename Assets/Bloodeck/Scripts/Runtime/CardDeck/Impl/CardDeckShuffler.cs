namespace Bloodeck
{
    public class CardDeckShuffler : ICardDeckShuffler
    {
        public void Shuffle(ICardDeck deck)
        {
            deck.Cards.Shuffle();
        }
    }
}