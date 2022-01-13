namespace Bloodeck
{
    public interface ICardPlayerData
    {
        ICards Cards { get; set; }

        int Energy { get; set; }

        int MaxEnergy { get; set; }
    }
}