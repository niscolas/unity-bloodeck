using System;

namespace Bloodeck
{
    public interface ICardHand : ICardHandData
    {
        event Action<ICard> Added;
        event Action<ICard> Removed;
        bool CheckIsFull();
    }
}