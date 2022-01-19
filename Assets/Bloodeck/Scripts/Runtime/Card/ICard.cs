namespace Bloodeck
{
    public interface ICard : ICardData
    {
        void LoadTemplate(ICardTemplate template);
    }
}