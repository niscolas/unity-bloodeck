using UnityEngine;

namespace Bloodeck.View
{
    public class PointerInputService : IPointerInputService
    {
        public float PositionX => Input.mousePosition.x;
        public float PositionY => Input.mousePosition.y;
        public Vector2 Position => Input.mousePosition;
    }
}