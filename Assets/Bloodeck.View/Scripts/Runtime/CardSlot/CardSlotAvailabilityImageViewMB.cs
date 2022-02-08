using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Bloodeck.View
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Slot Availability (Image) View")]
    public class CardSlotAvailabilityImageViewMB : CachedMB
    {
        [SerializeField]
        private CardSlotMB _cardSlot;

        [SerializeField]
        private Image _image;

        [SerializeField, ColorUsage(true, true)]
        private Color _availableColor;

        [SerializeField, ColorUsage(true, true)]
        private Color _unavailableColor;

        [Header(HeaderTitles.Debug)]
        [SerializeField, ColorUsage(true, true)]
        private Color _initialColor;

        [Inject]
        private HeldCard _heldCard;

        private void Start()
        {
            _initialColor = _image.color;
        }

        private void OnMouseEnter()
        {
            if (!enabled)
            {
                return;
            }

            if (_cardSlot.CanPlaceCard(_heldCard.Value))
            {
                UseAvailableColor();
            }
            else
            {
                UseUnavailableColor();
            }
        }

        private void OnMouseExit()
        {
            if (!enabled)
            {
                return;
            }

            ResetToInitialColor();
        }

        private void UseAvailableColor()
        {
            _image.color = _availableColor;
        }

        private void UseUnavailableColor()
        {
            _image.color = _unavailableColor;
        }

        private void ResetToInitialColor()
        {
            _image.color = _initialColor;
        }
    }
}