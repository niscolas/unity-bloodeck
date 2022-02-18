using System;
using System.Collections.Generic;
using System.Linq;
using niscolas.UnityUtils.Core.Extensions;

namespace Bloodeck
{
    public class MatchController : IMatch
    {
        public event Action<ITurn> TurnStarted;
        public event Action<ITurn> TurnEnded;

        public MatchState State => _humbleObject.State;
        public IList<ICardPlayer> Players => _humbleObject.Players;
        public ITurn CurrentTurn => _humbleObject.CurrentTurn;

        public int TurnCount => _humbleObject.TurnCount;

        private readonly IMatchHumbleObject _humbleObject;

        public MatchController(IMatchHumbleObject humbleObject)
        {
            _humbleObject = humbleObject;
        }

        public bool CheckAreOppositeTeams(ITeam team, ITeam otherTeam)
        {
            return team != otherTeam;
        }

        public void SetTurn(ITeam cardPlayerTeam)
        {
            ICardPlayer cardPlayer = GetCardPlayerInTeam(cardPlayerTeam);
            if (cardPlayer.IsUnityNull())
            {
                return;
            }

            NotifyOldTurnEnded();
            _humbleObject.SetCurrentTurnFromCardPlayer(cardPlayer);
            NotifyTurnStarted();
            IncrementTurnCount();
        }

        private void IncrementTurnCount()
        {
            SetTurnCount(TurnCount + 1);
        }

        private void NotifyOldTurnEnded()
        {
            if (!CurrentTurn.IsUnityNull())
            {
                TurnEnded?.Invoke(CurrentTurn);
            }
        }

        private void NotifyTurnStarted()
        {
            TurnStarted?.Invoke(CurrentTurn);
        }

        private ICardPlayer GetCardPlayerInTeam(ITeam cardPlayerTeam)
        {
            return Players.FirstOrDefault(x => x.SelfEntity.Team == cardPlayerTeam);
        }

        private void SetTurnCount(int value)
        {
            _humbleObject.SetTurnCount(value);
        }
    }
}