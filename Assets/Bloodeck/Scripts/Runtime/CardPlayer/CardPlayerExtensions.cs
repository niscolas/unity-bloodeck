namespace Bloodeck
{
    public static class CardPlayerExtensions
    {
        public static ICardPlayer WithCards(this ICardPlayer cardPlayer, ICards value)
        {
            cardPlayer.Cards = value;
            return cardPlayer;
        }

        public static ICardPlayer WithEnergy(this ICardPlayer cardPlayer, int value)
        {
            cardPlayer.Energy = value;
            return cardPlayer;
        }

        public static ICardPlayer WithMaxEnergy(this ICardPlayer cardPlayer, int value)
        {
            cardPlayer.MaxEnergy = value;
            return cardPlayer;
        }
    }
}