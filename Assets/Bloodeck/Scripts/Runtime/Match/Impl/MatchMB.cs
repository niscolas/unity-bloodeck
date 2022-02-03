using niscolas.UnityUtils.Core;
using UnityEngine;

namespace Bloodeck
{
    public enum MatchState
    {
        NotStarted,
        OnGoing,
        Victory,
        Defeat
    }

    public class MatchMB : CachedMB, IMatch
    {
        [SerializeField]
        private MatchState _state;

        [SerializeField]
        private SerializableCardPlayerMBCollection _players;

        [SerializeField]
        private SerializableTurn _currentTurn;

        public MatchState State => _state;

        public ICardPlayers Players => _players;

        public ITurn CurrentTurn => _currentTurn;
    }
}