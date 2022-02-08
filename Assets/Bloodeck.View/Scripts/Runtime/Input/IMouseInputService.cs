using UnityEngine;

namespace Bloodeck.View
{
    public interface IMouseInputService
    {
        float PositionX { get; }
        
        float PositionY { get; }
        
        Vector2 Position { get; }
    }
}