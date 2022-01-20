namespace Bloodeck
{
    public interface IDeckData
    {
        ICardFromTemplateFactory CardFromTemplateFactory { get; }

        ICards Cards { get; }

        IDeckShuffler Shuffler { get; }

        IDeckTemplate Template { get; set; }
    }
}