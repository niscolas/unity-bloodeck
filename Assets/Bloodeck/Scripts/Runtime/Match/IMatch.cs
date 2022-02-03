namespace Bloodeck
{
    public interface IMatch
    {
        MatchState State { get; }

        ICardPlayers Players { get; }

        ITurn CurrentTurn { get; }
    }
}