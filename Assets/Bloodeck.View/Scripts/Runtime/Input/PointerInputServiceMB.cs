using System;
using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Void = UnityAtoms.Void;

namespace Bloodeck.View
{
    public class PointerInputServiceMB : CachedMB, IPointerInputService
    {
        [SerializeField]
        private IntReference _maxRaycastTargets = new IntReference(2);

        [SerializeField]
        private FloatReference _defaultRaycastMaxDistance = new FloatReference(100f);

        [SerializeField]
        private LayerMask _defaultRaycastLayerMask;

        [field: Header(HeaderTitles.Debug)]
        [field: SerializeField]
        public Vector2 Position { get; private set; }

        public event Action<RaycastHit[]> Clicked;

        public float PositionX { get; private set; }

        public float PositionY { get; private set; }

        private Camera _camera;
        private RaycastHit[] _results;

        protected override void Awake()
        {
            base.Awake();

            _camera = Camera.main;
            _results = new RaycastHit[_maxRaycastTargets.Value];
        }

        private void Update()
        {
            CachePosition();

            if (!Input.GetMouseButtonUp(0))
            {
                return;
            }

            Clicked?.Invoke(ShootRaycastFromPointerPosition());
        }

        private void CachePosition()
        {
            Position = Input.mousePosition;
            PositionX = Position.x;
            PositionY = Position.y;
        }

        public Ray GetScreenPointToRay()
        {
            return _camera.ScreenPointToRay(Position);
        }

        public RaycastHit[] ShootRaycastFromPointerPosition()
        {
            return ShootRaycastFromPointerPosition(_defaultRaycastLayerMask);
        }

        public RaycastHit[] ShootRaycastFromPointerPosition(
            LayerMask layerMaskOverride, float maxDistanceOverride = -1)
        {
            if (maxDistanceOverride <= 0)
            {
                maxDistanceOverride = _defaultRaycastMaxDistance.Value;
            }

            int resultCount = Physics.RaycastNonAlloc(
                GetScreenPointToRay(), _results, maxDistanceOverride, layerMaskOverride);

            return _results.NewArrayFromBetweenIndexes(0, resultCount - 1);
        }
    }
}