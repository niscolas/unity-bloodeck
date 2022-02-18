using niscolas.UnityUtils.Core;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Bloodeck.View.VisualScripting
{
    public class CardPlayerVSEventsMB : CachedMB
    {
        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private CardPlayerMB _cardPlayer;

        public const string CardPlayer_OnCardDeployedCustomEventName =
            nameof(CardPlayer_OnCardDeployedCustomEventName);

        private void OnEnable()
        {
            _cardPlayer.CardDeployed += CardPlayer_OnCardDeployed;
        }

        private void OnDisable()
        {
            _cardPlayer.CardDeployed -= CardPlayer_OnCardDeployed;
        }

        private void CardPlayer_OnCardDeployed(ICard card)
        {
            CustomEvent.Trigger(
                _gameObject, CardPlayer_OnCardDeployedCustomEventName, (CardMB) card);
        }
    }
}