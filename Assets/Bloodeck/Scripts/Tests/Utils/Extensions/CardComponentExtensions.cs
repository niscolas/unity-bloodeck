using NSubstitute;

namespace Bloodeck.Tests.Utils
{
    public static class CardComponentExtensions
    {
        public static T Sub_WithOwner<T>(this T self, ICard value) where T : ICardComponent
        {
            self.Owner.Returns(value);
            return self;
        }
    }
}