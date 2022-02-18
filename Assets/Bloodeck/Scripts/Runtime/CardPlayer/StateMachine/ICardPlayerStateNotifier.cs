using System;

namespace Bloodeck
{
    public interface ICardPlayerStateNotifier
    {
        event Action<ICardPlayerStateTag> StateChanged;
    }
}