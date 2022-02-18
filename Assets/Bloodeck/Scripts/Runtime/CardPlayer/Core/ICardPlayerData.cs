namespace Bloodeck
{
    public interface ICardPlayerData
    {
        IEntity SelfEntity { get; }
        IDeck Deck { get; set; }
        int Energy { get; set; }
        int MaxEnergy { get; set; }
        ICardPlayerEnvironment Environment { get; }
        ICardHand Hand { get; }
        ICardPlayerStateNotifier StateNotifier { get; }
        bool IsMakingMove { get; }
        bool HasDrawnInitialCards { get; }
        bool IsDrawingStartingCards { get; }
        float DrawCardIntervalSeconds { get; }
        int InitialDrawCardsCount { get; }
        int CardDrawCost { get; }
    }
}