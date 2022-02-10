using UnityEngine;

namespace Bloodeck.View
{
    public interface IPointerInputService
    {
        float PositionX { get; }
        
        float PositionY { get; }
        
        Vector2 Position { get; }
    }
}