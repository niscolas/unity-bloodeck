using NSubstitute;

namespace Bloodeck.Tests.Utils
{
    public static class CardPlayerExtensions
    {
        public static ICardPlayer Sub_WithCardHand(this ICardPlayer self, ICardHand value)
        {
            self.Hand.Returns(value);
            return self;
        }

        public static ICardPlayer Sub_WithEnvironment(this ICardPlayer self, ICardPlayerEnvironment value)
        {
            self.Environment.Returns(value);
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