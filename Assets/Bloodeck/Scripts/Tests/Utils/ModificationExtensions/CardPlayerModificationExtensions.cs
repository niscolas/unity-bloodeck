using NSubstitute;

namespace Bloodeck.Tests.Utils
{
    public static class CardPlayerModificationExtensions
    {
        public static ICardPlayer WithCards(this ICardPlayer cardPlayer, ICards value)
        {
            cardPlayer.Cards = value;
            return cardPlayer;
        }
        
        public static ICardPlayer Substitute_WithCards(this ICardPlayer substitute, ICards value)
        {
            substitute.Cards.Returns(value);
            return substitute;
        }
        
        public static ICardPlayer WithEnergy(this ICardPlayer cardPlayer, int value)
        {
            cardPlayer.Energy = value;
            return cardPlayer;
        }

        public static ICardPlayer Substitute_WithEnergy(this ICardPlayer substitute, int value)
        {
            substitute.Energy.Returns(value);
            return substitute;
        }

        public static ICardPlayer WithMaxEnergy(this ICardPlayer cardPlayer, int value)
        {
            cardPlayer.MaxEnergy = value;
            return cardPlayer;
        }

        public static ICardPlayer Substitute_WithMaxEnergy(this ICardPlayer substitute, int value)
        {
            substitute.MaxEnergy.Returns(value);
            return substitute;
        }
    }
}