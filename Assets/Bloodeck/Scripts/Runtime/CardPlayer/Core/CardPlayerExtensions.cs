using System.Collections.Generic;
using System.Linq;
using niscolas.UnityUtils.Core.Extensions;

namespace Bloodeck
{
    public static class CardPlayerExtensions
    {
        public static ICardPlayer WithEnergy(this ICardPlayer self, int value)
        {
            self.Energy = value;
            return self;
        }

        public static ICardPlayer WithMaxEnergy(this ICardPlayer self, int value)
        {
            self.MaxEnergy = value;
            return self;
        }

        public static bool CheckCanAfford(this ICardPlayer self, ICard card)
        {
            return self.Energy >= card.Cost;
        }

        public static bool CheckCanAffordAnyCard(this ICardPlayer self)
        {
            return self.Hand.Any(self.CheckCanAfford);
        }

        public static IEnumerable<ICard> GetAffordableCards(this ICardPlayer self)
        {
            return self.Hand.Where(card => card.Cost <= self.Energy);
        }

        public static ICard[] GetAffordableCardsAsArray(this ICardPlayer self)
        {
            return self.GetAffordableCards().ToArray();
        }
    }
}