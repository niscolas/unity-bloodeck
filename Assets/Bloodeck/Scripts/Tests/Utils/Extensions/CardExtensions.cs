using NSubstitute;

namespace Bloodeck.Tests.Utils
{
    public static class CardExtensions
    {
        public static ICard Sub_WithCost(this ICard substitute, int value)
        {
            substitute.Cost.Returns(value);
            return substitute;
        }
    }
}