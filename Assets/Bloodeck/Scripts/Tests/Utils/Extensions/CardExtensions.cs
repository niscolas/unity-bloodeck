using NSubstitute;

namespace Bloodeck.Tests.Utils
{
    public static class CardExtensions
    {
        public static ICard Sub_WithCost(this ICard self, int value)
        {
            self.Cost.Returns(value);
            return self;
        }
    }
}