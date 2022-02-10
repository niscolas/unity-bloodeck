using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Bloodeck.View
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Slot Availability (Image) View")]
    public class CardSlotAvailabilityImageViewMB : CardSlotAvailabilityViewMB
    {
        [SerializeField]
        private Image _image;

        [SerializeField, ColorUsage(true, true)]
        private Color _availableColor;

        [SerializeField, ColorUsage(true, true)]
        private Color _unavailableColor;

        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private CardSlotMB _selfCardSlot;

        [Header(HeaderTitles.Debug)]
        [SerializeField, ColorUsage(true, true)]
        private Color _initialColor;

        [Inject]
        private CardDraggerMB _cardDragger;

        private void Start()
        {
            _initialColor = _image.color;
        }

        public override void Check()
        {
            if (_selfCardSlot.HasCard)
            {
                ResetState();
                return;
            }

            if (_selfCardSlot.CanPlaceCard(_cardDragger.DraggedCard))
            {
                UseAvailableColor();
            }
            else
            {
                UseUnavailableColor();
            }
        }

        public override void ResetState()
        {
            _image.color = _initialColor;
        }

        private void UseAvailableColor()
        {
            _image.color = _availableColor;
        }

        private void UseUnavailableColor()
        {
            _image.color = _unavailableColor;
        }
    }
}