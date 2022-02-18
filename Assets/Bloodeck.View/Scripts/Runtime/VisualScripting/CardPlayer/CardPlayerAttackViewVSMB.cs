using niscolas.UnityUtils.Core;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Bloodeck.View.VisualScripting
{
    public class CardPlayerAttackViewVSMB : CachedMB
    {
        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private CardPlayerAttackPointerViewMB _cardPlayerAttack;

        public const string CardPlayerAttackView_CardSelectedCustomEventName =
            nameof(CardPlayerAttackView_CardSelectedCustomEventName);

        private void OnEnable()
        {
            _cardPlayerAttack.CardSelected += CardPlayerAttack_OnCardSelected;
        }

        private void OnDisable()
        {
            _cardPlayerAttack.CardSelected -= CardPlayerAttack_OnCardSelected;
        }

        private void CardPlayerAttack_OnCardSelected(CardMB card)
        {
            CustomEvent.Trigger(
                _gameObject, CardPlayerAttackView_CardSelectedCustomEventName, card);
        }
    }
}