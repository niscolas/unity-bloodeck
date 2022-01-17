using NSubstitute;

namespace Bloodeck.Tests.Utils
{
    public static class CardPlayerEnvironmentExtensions
    {
        public static ICardPlayerEnvironment Sub_WithSlots(this ICardPlayerEnvironment self, ICardSlots value)
        {
            self.Slots.Returns(value);
            return self;
        }
    }
}