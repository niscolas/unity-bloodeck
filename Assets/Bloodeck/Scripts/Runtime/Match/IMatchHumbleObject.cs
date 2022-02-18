namespace Bloodeck
{
    public interface IMatchHumbleObject : IMatchData
    {
        void SetCurrentTurnFromCardPlayer(ICardPlayer cardPlayer);
        void SetTurnCount(int value);
    }
}