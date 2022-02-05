namespace Bloodeck
{
    public interface ICardPlayerData
    {
        IDeck Deck { get; set; }

        IDeckFromTemplateFactory DeckFromTemplateFactory { get; }

        int Energy { get; set; }

        int MaxEnergy { get; set; }

        ICardPlayerEnvironment Environment { get; }

        ICardHand Hand { get; }
        
        bool IsMakingMove { get; }
        
        bool IsDrawingStartingCards { get; }
        
        float DrawCardIntervalSeconds { get; }
        
        int InitialDrawCardsCount { get; }
    }
}