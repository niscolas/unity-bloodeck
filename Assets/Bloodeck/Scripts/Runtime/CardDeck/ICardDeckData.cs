namespace Bloodeck
{
    public interface ICardDeckData
    {
        ICardFromTemplateFactory CardFromTemplateFactory { get; }

        ICardsFactory CardsFactory { get; }

        ICardTemplates CardTemplates { get; }
    }
}