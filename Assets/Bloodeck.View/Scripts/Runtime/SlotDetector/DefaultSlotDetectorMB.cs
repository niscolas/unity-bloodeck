using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Bloodeck.View
{
    public class DefaultSlotDetectorMB : SlotDetectorMB
    {
        [SerializeField]
        private Vector3Reference _cardSlotCheckDir = new Vector3Reference(new Vector3(0, 0, 1));

        [SerializeField]
        private LayerMask _cardSlotCheckLayerMask;

        [SerializeField]
        private FloatReference _cardSlotCheckMaxDistance = new FloatReference(1000f);

        [SerializeField]
        private FloatReference _cardSlotCheckRadius = new FloatReference(15f);

        private void Update()
        {
            CheckCardSlot();
        }

        private void CheckCardSlot()
        {
            if (!TryDetectCardSlot(out RaycastHit hit))
            {
                ResetSelectedCardSlot();
                return;
            }

            CardSlotMB slotHit = hit.collider.GetComponentInChildren<CardSlotMB>();
            if (!slotHit)
            {
                ResetSelectedCardSlot();
                return;
            }

            if (slotHit == _selectedSlot)
            {
                return;
            }

            ResetSelectedCardSlot();
            _selectedSlot = slotHit;
            _selectableCardSlot = _selectedSlot.GetComponentInChildren<SelectableCardSlotMB>();
            _selectableCardSlot.Select();
        }

        private bool TryDetectCardSlot(out RaycastHit hit)
        {
            return Physics.Raycast(
                GetCardSlotCheckOrigin(),
                // _cardSlotCheckRadius.Value,
                GetCardSlotCheckDirection(),
                out hit,
                _cardSlotCheckMaxDistance.Value,
                _cardSlotCheckLayerMask);
        }

        private Vector3 GetCardSlotCheckDirection()
        {
            return _transform.TransformDirection(_cardSlotCheckDir.Value);
        }

        private Vector3 GetCardSlotCheckOrigin()
        {
            return _transform.position;
        }
    }
}