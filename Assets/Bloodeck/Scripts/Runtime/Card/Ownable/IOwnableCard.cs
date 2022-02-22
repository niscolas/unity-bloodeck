using System;

namespace Bloodeck
{
    public interface IOwnableCard
    {
        event Action<ICardPlayer> OwnerChanged;
        event Action<(ICardPlayer, ICardPlayer)> OwnerChangedWithHistory;

        ICardPlayer Owner { get; }
        ICardPlayer PreviousOwner { get; }

        void SetOwner(ICardPlayer owner);
    }
}