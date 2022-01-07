using NSubstitute;

namespace Bloodeck.Tests.Utils
{
    public static class CardSubstituteModificationExtensions
    {
        public static ICard WithCost(this ICard card, int value)
        {
            card.Cost = value;
            return card;
        }
        
        public static ICard Substitute_WithCost(this ICard substitute, int value)
        {
            substitute.Cost.Returns(value);
            return substitute;
        }
    }
}