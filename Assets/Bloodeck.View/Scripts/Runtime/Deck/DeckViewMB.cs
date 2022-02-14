using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Zenject;

namespace Bloodeck.View
{
    public class DeckViewMB : CachedMB
    {
        [SerializeField]
        private FloatReference _cardMoveSpeed = new FloatReference();

        [SerializeField]
        private Transform _cardPositionReference;

        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private DeckMB _deck;

        [Inject]
        private IUnityTimeService _timeService;

        private Vector3 _currentCardPositionReferencePosition;

        private void Start()
        {
            if (!_cardPositionReference)
            {
                _cardPositionReference = _transform;
            }
        }

        private void Update()
        {
            _currentCardPositionReferencePosition = _cardPositionReference.position;
            _deck.Cards.ForEach(x => UpdateCard(x as CardMB));
        }

        private void UpdateCard(CardMB card)
        {
            if (!card.gameObject.activeSelf)
            {
                return;
            }

            float t = _timeService.DeltaTime * _cardMoveSpeed.Value;
            Vector3 cardPosition = card.transform.position;

            if (Vector3.Distance(cardPosition, _currentCardPositionReferencePosition) < 0.1f)
            {
                card.gameObject.SetActive(false);
                return;
            }

            card.transform.position = Vector3.Lerp(
                cardPosition,
                _cardPositionReference.position,
                t);
        }
    }
}