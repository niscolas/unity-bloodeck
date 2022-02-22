using System;

namespace Bloodeck
{
    public interface IMatch : IMatchData
    {
        event Action<ITurn> TurnStarted;
        event Action<ITurn> TurnEnded;

        ICardPlayer GetOpponent(ICardPlayer cardPlayer);
        bool CheckAreOppositeTeams(ITeam team, ITeam otherTeam);
        void SetTurn(ITeam cardPlayerTeam);
    }
}