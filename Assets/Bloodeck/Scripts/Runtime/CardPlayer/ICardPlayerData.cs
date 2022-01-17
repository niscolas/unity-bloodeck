namespace Bloodeck
{
    public interface ICardPlayerData
    {
        ICardPlayerEnvironment Environment { get; }

        ICards Cards { get; set; }

        int Energy { get; set; }

        int MaxEnergy { get; set; }
    }
}