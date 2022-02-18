using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Zenject;

namespace Bloodeck.View
{
    public class CardTableMB : CachedMB
    {
        [SerializeField]
        private LayerMask _tableLayerMask;

        [SerializeField]
        private Vector3Reference _surfacePositionOffset = new Vector3Reference(new Vector3(0, 0, -2));

        [Inject]
        private IPointerInputService _pointerInputService;

        public Vector3 GetPointerPositionOnSurface()
        {
            RaycastHit[] raycastHits = _pointerInputService
                .ShootRaycastFromPointerPosition(_tableLayerMask);

            if (raycastHits.CheckIsEmpty())
            {
                return default;
            }

            Vector3 nearestHitPoint = raycastHits.GetNearestRaycastHit().point;
            return AddSurfacePositionOffset(nearestHitPoint);
        }

        private Vector3 AddSurfacePositionOffset(Vector3 value)
        {
            value += _transform.TransformVector(_surfacePositionOffset.Value);
            return value;
        }
    }
}