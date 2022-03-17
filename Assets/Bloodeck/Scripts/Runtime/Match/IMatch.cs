using System;

namespace Bloodeck
{
    public interface IMatch : IMatchData
    {
        event Action<ITurn> TurnStarted;
        event Action<ITurn> TurnEnded;

        ICardPlayer GetOpponentCardPlayer(ICardPlayer cardPlayer);
        ITeam GetOpponentTeam(ITeam team);
        bool CheckAreOppositeTeams(ITeam team, ITeam otherTeam);
        void SetTurn(ITeam cardPlayerTeam);
    }
}