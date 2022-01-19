namespace Bloodeck
{
    public interface ICardDeckData
    {
        ICardFromTemplateFactory CardFromTemplateFactory { get; }

        ICards Cards { get; }

        ICardDeckShuffler Shuffler { get; }

        ICardDeckTemplate Template { get; set; }
    }
}