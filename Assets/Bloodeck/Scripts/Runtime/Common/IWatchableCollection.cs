using System;

namespace Bloodeck
{
    public interface IWatchableCollection<T>
    {
        event Action<T> Added;
        event Action<T> Removed;
        event Action Changed;
        event Action Cleared;
    }
}