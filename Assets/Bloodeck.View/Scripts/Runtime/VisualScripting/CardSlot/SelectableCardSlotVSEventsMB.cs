using System;
using niscolas.UnityUtils.Core;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Bloodeck.View.VisualScripting
{
    public class SelectableCardSlotVSEventsMB : CachedMB
    {
        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private SelectableCardSlotMB _selectableCardSlot;

        public const string SelectedCustomEventName = nameof(SelectableCardSlotMB.Selected);
        public const string DeselectedCustomEventName = nameof(SelectableCardSlotMB.Deselected);

        private void OnEnable()
        {
            _selectableCardSlot.Selected += OnSelected;
            _selectableCardSlot.Deselected += OnDeselected;
        }

        private void OnDisable()
        {
            _selectableCardSlot.Selected -= OnSelected;
            _selectableCardSlot.Deselected -= OnDeselected;
        }

        private void OnSelected()
        {
            CustomEvent.Trigger(_gameObject, SelectedCustomEventName);
        }

        private void OnDeselected()
        {
            CustomEvent.Trigger(_gameObject, DeselectedCustomEventName);
        }
    }
}