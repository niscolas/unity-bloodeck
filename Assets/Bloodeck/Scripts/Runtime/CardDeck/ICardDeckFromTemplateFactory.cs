namespace Bloodeck
{
    public interface ICardDeckFromTemplateFactory
    {
        ICardDeck Create(ICardDeckTemplate template);
    }
}