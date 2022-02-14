using System;

namespace Bloodeck
{
    public interface ICard : ICardData
    {
        event Action Destroyed;
        void LoadTemplate(ICardTemplate template);
    }
}