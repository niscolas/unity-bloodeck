using System;
using UnityEngine;

namespace Bloodeck.View
{
    public interface IPointerInputService
    {
        event Action<RaycastHit[]> Clicked;

        float PositionX { get; }
        float PositionY { get; }
        Vector2 Position { get; }

        Ray GetScreenPointToRay();
        RaycastHit[] ShootRaycastFromPointerPosition();
        RaycastHit[] ShootRaycastFromPointerPosition(LayerMask layerMaskOverride, float maxDistanceOverride = -1);
    }
}