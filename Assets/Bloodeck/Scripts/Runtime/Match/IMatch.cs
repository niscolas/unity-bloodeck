using System;

namespace Bloodeck
{
    public interface IMatch : IMatchData
    {
        event Action<ITurn> TurnStarted;
        event Action<ITurn> TurnEnded;

        bool CheckAreOppositeTeams(ITeam team, ITeam otherTeam);
        void SetTurn(ITeam cardPlayerTeam);
    }
}