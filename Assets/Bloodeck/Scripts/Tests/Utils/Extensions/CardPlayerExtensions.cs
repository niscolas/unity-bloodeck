using NSubstitute;

namespace Bloodeck.Tests.Utils
{
    public static class CardPlayerExtensions
    {
        public static ICardPlayer Substitute_WithCards(this ICardPlayer self, ICards value)
        {
            self.Cards.Returns(value);
            return self;
        }

        public static ICardPlayer Sub_WithEnergy(this ICardPlayer self, int value)
        {
            self.Energy.Returns(value);
            return self;
        }

        public static ICardPlayer Sub_WithMaxEnergy(this ICardPlayer self, int value)
        {
            self.MaxEnergy.Returns(value);
            return self;
        }
    }
}