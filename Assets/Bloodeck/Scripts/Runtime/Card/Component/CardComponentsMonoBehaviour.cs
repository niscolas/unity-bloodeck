using UnityEngine;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Components")]
    public class CardComponentsMonoBehaviour :
        BaseComponentsMonoBehaviour<ICardComponent, BaseCardComponentMonoBehaviour>,
        ICardComponents { }
}