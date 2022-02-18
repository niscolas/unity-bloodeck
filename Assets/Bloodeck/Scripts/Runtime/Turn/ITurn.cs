namespace Bloodeck
{
    public interface ITurn
    {
        ITeam Team { get; }
        ICardPlayer Player { get; }
    }
}