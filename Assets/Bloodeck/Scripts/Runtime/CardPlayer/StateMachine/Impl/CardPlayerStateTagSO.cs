using UnityEngine;

namespace Bloodeck
{
    [CreateAssetMenu(
        fileName = "CardPlayerStateTag",
        menuName = Constants.CreateAssetMenuPrefix + "Card Player State Tag",
        order = Constants.CreateAssetMenuOrder)]
    public class CardPlayerStateTagSO : ScriptableObject, ICardPlayerStateTag { }
}