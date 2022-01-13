using UnityEngine;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Components")]
    public class CardComponentsMB :
        BaseComponentsMB<ICardComponent, BaseCardComponentMB>, ICardComponents { }
}