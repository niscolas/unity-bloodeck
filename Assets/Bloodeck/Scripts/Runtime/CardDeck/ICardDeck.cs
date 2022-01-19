namespace Bloodeck
{
    public interface ICardDeck : ICardDeckData
    {
        void LoadTemplate(ICardDeckTemplate template);
    }
}