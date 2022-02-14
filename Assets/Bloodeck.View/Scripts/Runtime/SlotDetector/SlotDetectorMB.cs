using System;
using niscolas.UnityUtils.Core;
using UnityEngine;

namespace Bloodeck.View
{
    public abstract class SlotDetectorMB : CachedMB
    {
        [Header(HeaderTitles.Debug)]
        [SerializeField]
        protected CardSlotMB _selectedSlot;

        [SerializeField]
        protected SelectableCardSlotMB _selectableCardSlot;

        public CardSlotMB SelectedSlot => _selectedSlot;

        public SelectableCardSlotMB SelectableCardSlot => _selectableCardSlot;

        public void ResetSelectedCardSlot()
        {
            _selectedSlot = default;

            if (_selectableCardSlot)
            {
                _selectableCardSlot.Deselect();
                _selectableCardSlot = default;
            }
        }

        public void ResetData()
        {
            _selectedSlot = default;
            _selectableCardSlot = default;
        }
    }
}