using System.Collections.Generic;

namespace Bloodeck
{
    public interface IDeckData : IEnumerable<ICard>
    {
        int Count { get; }
        ICardFromTemplateFactory CardFromTemplateFactory { get; }
        IDeckShuffler Shuffler { get; }
        IDeckTemplate LoadedTemplate { get; }
    }
}