namespace Bloodeck
{
    public interface ICardDeckData
    {
        ICardFromTemplateFactory CardFromTemplateFactory { get; }

        ICards Cards { get; }
        
        ICardDeckTemplate Template { get; set; }
    }
}