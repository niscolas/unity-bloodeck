namespace Bloodeck
{
    public interface ICardDeck : ICardDeckData
    {
        ICards Instantiate();
    }
}