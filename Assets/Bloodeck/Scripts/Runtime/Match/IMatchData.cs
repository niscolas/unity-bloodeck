using System.Collections.Generic;

namespace Bloodeck
{
    public interface IMatchData
    {
        MatchState State { get; }
        IList<ICardPlayer> Players { get; }
        ITurn CurrentTurn { get; }
        int TurnCount { get; }
    }
}