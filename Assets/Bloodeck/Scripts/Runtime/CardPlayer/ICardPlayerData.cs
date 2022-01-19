namespace Bloodeck
{
    public interface ICardPlayerData
    {
        IDeck Deck { get; set; }

        IDeckFromTemplateFactory DeckFromTemplateFactory { get; }

        ICardHand Hand { get; }

        int Energy { get; set; }

        ICardPlayerEnvironment Environment { get; }

        int MaxEnergy { get; set; }
    }
}