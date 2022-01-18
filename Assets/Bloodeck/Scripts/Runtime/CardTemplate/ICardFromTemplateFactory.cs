namespace Bloodeck
{
    public interface ICardFromTemplateFactory
    {
        ICard Create(ICardTemplate template);
    }
}