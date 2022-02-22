using niscolas.UnityUtils.Core;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Bloodeck.View.VisualScripting
{
    public class MatchSubjectVSMB : CachedMB
    {
        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private MatchSubjectMB _matchSubject;

        public const string MatchSubject_OnSelfTurnStartedCustomEventName =
            nameof(MatchSubject_OnSelfTurnStartedCustomEventName);

        public const string MatchSubject_OnOpponentTurnStartedCustomEventName =
            nameof(MatchSubject_OnOpponentTurnStartedCustomEventName);

        private void OnEnable()
        {
            _matchSubject.SelfTurnStarted += MatchSubject_OnSelfTurnStarted;
            _matchSubject.OpponentTurnStarted += MatchSubject_OnOpponentTurnStarted;
        }

        private void OnDisable()
        {
            _matchSubject.SelfTurnStarted -= MatchSubject_OnSelfTurnStarted;
            _matchSubject.OpponentTurnStarted -= MatchSubject_OnOpponentTurnStarted;
        }

        private void MatchSubject_OnSelfTurnStarted()
        {
            CustomEvent.Trigger(_gameObject, MatchSubject_OnSelfTurnStartedCustomEventName);
        }

        private void MatchSubject_OnOpponentTurnStarted()
        {
            CustomEvent.Trigger(_gameObject, MatchSubject_OnOpponentTurnStartedCustomEventName);
        }
    }
}