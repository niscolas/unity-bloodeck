namespace Bloodeck
{
    public interface ICardPlayerData
    {
        ICardDeck Deck { get; set; }

        ICardDeckFromTemplateFactory DeckFromTemplateFactory { get; }

        ICardHand Hand { get; }

        int Energy { get; set; }

        ICardPlayerEnvironment Environment { get; }

        int MaxEnergy { get; set; }
    }
}