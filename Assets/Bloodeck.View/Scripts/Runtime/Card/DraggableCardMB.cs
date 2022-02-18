using System;
using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Zenject;

namespace Bloodeck.View
{
    public class DraggableCardMB : CachedMB
    {
        [SerializeField]
        private FloatReference _dragSpeed = new FloatReference(10f);

        [SerializeField]
        private BoolReference _isBeingDragged = new BoolReference();

        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private CardMB _selfCard;

        [Inject, SerializeField]
        private CardTableMB _cardTable;

        [Inject, SerializeField]
        private CardGameEnvironmentMB _cardGameEnvironment;

        public event Action<bool> DragStateChanged;

        public bool IsBeingDragged
        {
            get => _isBeingDragged.Value;
            set
            {
                _isBeingDragged.Value = value;
                DragStateChanged?.Invoke(value);
            }
        }

        [Inject]
        private CardDraggerMB _cardDragger;

        [Inject]
        private IUnityTimeService _timeService;

        [Inject]
        private IPointerInputService _pointerInputService;

        private void Update()
        {
            Drag();
        }

        public void BeginDrag()
        {
            _cardDragger.BeginDrag(_selfCard);
            IsBeingDragged = true;
        }

        private void Drag()
        {
            if (IsBeingDragged)
            {
                DragRaw();
            }
        }

        private void DragRaw()
        {
            _transform.position = Vector3.Lerp(
                _transform.position,
                GetDragPosition(),
                _timeService.DeltaTime * _dragSpeed.Value);

            _transform.rotation = _cardGameEnvironment.transform.rotation;
        }

        private Vector3 GetDragPosition()
        {
            return _cardTable.GetPointerPositionOnSurface();
        }

        public void EndDrag()
        {
            _cardDragger.EndDrag();
            IsBeingDragged = false;
        }
    }
}