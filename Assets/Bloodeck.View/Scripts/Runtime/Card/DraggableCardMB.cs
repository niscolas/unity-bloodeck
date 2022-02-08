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
        private IUnityTimeService _timeService;

        [Inject]
        private IMouseInputService _mouseInputService;

        public void Drag()
        {
            if (IsBeingDragged)
            {
                DragRaw();
            }
        }

        public void DragRaw()
        {
            _transform.position = Vector3.Lerp(
                _transform.position,
                _mouseInputService.Position,
                _timeService.DeltaTime * _dragSpeed.Value);

            // _transform.SetParent(GameReference.tableObject, false);
            // _transform.rotation = GameReference.tableObject.rotation;
        }
    }
}