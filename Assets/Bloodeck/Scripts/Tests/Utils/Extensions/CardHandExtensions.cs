using NSubstitute;

namespace Bloodeck.Tests.Utils
{
    public static class CardHandExtensions
    {
        public static ICardHand Sub_WithCards(this ICardHand self, ICards value)
        {
            self.Cards.Returns(value);
            return self;
        }
    }
}