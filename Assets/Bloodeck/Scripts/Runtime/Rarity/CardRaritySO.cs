using Lingua;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [CreateAssetMenu(
        fileName = "CardRarity",
        menuName = Constants.CreateAssetMenuPrefix + "Card Rarity",
        order = Constants.CreateAssetMenuOrder)]
    public class CardRaritySO : ScriptableObject
    {
        [Inject(Id = ZenjectIds.TextFieldId), SerializeReference]
        private INoContextText _displayName;
    }
}