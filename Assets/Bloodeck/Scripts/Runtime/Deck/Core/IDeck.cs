using System;

namespace Bloodeck
{
    public interface IDeck : IDeckData
    {
        event Action<ICard> CardCreated;
        event Action<ICard> Added;
        event Action Changed;
        
        ICard DrawFromTop();
        void Add(ICard card);
        bool Remove(ICard card);
        bool Contains(ICard card);
        bool ReturnCard(ICard card);
        void LoadTemplate(IDeckTemplate template);
    }
}