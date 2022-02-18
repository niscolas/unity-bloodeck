using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Bloodeck.View.VisualScripting
{
    public class MatchVSVariablesMB : CachedMB
    {
        [SerializeField]
        private VoidBaseEventReference _humanTurnEndedEvent;

        [SerializeField]
        private VoidBaseEventReference _aiTurnEndedEvent;

        public VoidBaseEventReference HumanTurnEndedEvent => _humanTurnEndedEvent;

        public VoidBaseEventReference AITurnEndedEvent => _aiTurnEndedEvent;
    }
}