using niscolas.UnityUtils.Core;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Bloodeck.View.VisualScripting
{
    public class DraggableCardVSEvents : CachedMB
    {
        [Inject, SerializeField]
        private DraggableCardMB _draggableCard;

        public const string DragStateChangedEventName = nameof(DraggableCardMB.DragStateChanged);

        private void OnEnable()
        {
            _draggableCard.DragStateChanged += OnDragStateChanged;
        }

        private void OnDisable()
        {
            _draggableCard.DragStateChanged -= OnDragStateChanged;
        }

        private void OnDragStateChanged(bool value)
        {
            CustomEvent.Trigger(_gameObject, DragStateChangedEventName, value);
        }
    }
}