namespace Bloodeck
{
    public static class CardExtensions
    {
        public static ICard WithCost(this ICard self, int value)
        {
            self.Cost = value;
            return self;
        }
    }
}