using System;
using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck.View
{
    public class CardDeployerMB : CachedMB
    {
        [SerializeField]
        private LayerMask _tableLayerMask;

        [Header(HeaderTitles.Debug)]
        [ReadOnly, SerializeField]
        private CardSlotMB _selectedCardSlot;

        public CardSlotMB SelectedCardSlot
        {
            get => _selectedCardSlot;
            set => _selectedCardSlot = value;
        }

        [Inject]
        private IPointerInputService _pointerInputService;

        [Inject]
        private Camera _camera;

        public Vector3 GetPositionOnTable()
        {
            Ray ray = _camera.ScreenPointToRay(_pointerInputService.Position);
            if (!Physics.Raycast(ray, out RaycastHit hit, 10000, _tableLayerMask))
            {
                return default;
            }

            return hit.point;
        }
    }
}