namespace Bloodeck.Card
{
    public static class CardExtensions
    {
        public static ICard WithCost(this ICard card, int value)
        {
            card.Cost = value;
            return card;
        }
    }
}