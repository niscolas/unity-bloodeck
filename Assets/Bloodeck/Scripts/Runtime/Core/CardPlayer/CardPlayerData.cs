namespace Bloodeck
{
    public class CardPlayerData : ICardPlayerData
    {
        public ICards Cards { get; set; }

        public int Energy { get; set; }

        public int MaxEnergy { get; set; }

        public CardPlayerData(
            ICards cards, int energy = default, int maxEnergy = default)
        {
            Cards = cards;
            Energy = energy;
            MaxEnergy = maxEnergy;
        }
    }
}