using System.Collections.Generic;
using System.Linq;

namespace Bloodeck
{
    public static class CardPlayerEnvironmentExtensions
    {
        public static ICardSlot GetRandomFreeSlot(this ICardPlayerEnvironment self)
        {
            return self.Slots.FirstOrDefault(x => x.CheckIsEmpty());
        }

        public static IEnumerable<ICard> GetCards(this ICardPlayerEnvironment self)
        {
            return self.Slots
                .Where(x => !x.CheckIsEmpty())
                .Select(x => x.Card);
        }

        public static ICard[] GetCardsAsArray(this ICardPlayerEnvironment self)
        {
            return self.GetCards().ToArray();
        }
    }
}