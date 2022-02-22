using niscolas.UnityUtils.Core;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Bloodeck.View.VisualScripting
{
    public class MatchVSMB : CachedMB
    {
        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private MatchMB _match;

        public const string Match_OnTurnStartedCustomEventName =
            nameof(Match_OnTurnStartedCustomEventName);

        private void OnEnable()
        {
            _match.TurnStarted += Match_OnTurnStarted;
        }

        private void OnDisable()
        {
            _match.TurnStarted -= Match_OnTurnStarted;
        }

        private void Match_OnTurnStarted(ITurn turn)
        {
            CustomEvent.Trigger(
                _gameObject,
                Match_OnTurnStartedCustomEventName,
                (SerializableTurn) turn);
        }
    }
}