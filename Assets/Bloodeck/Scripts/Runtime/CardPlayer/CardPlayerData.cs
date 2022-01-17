namespace Bloodeck
{
    public class CardPlayerData : ICardPlayerData
    {
        public ICardPlayerEnvironment Environment { get; }

        public ICards Cards { get; set; }

        public int Energy { get; set; }

        public int MaxEnergy { get; set; }

        public CardPlayerData(
            ICards cards,
            ICardPlayerEnvironment environment,
            int energy = default,
            int maxEnergy = default)
        {
            Cards = cards;
            Environment = environment;
            Energy = energy;
            MaxEnergy = maxEnergy;
        }
    }
}