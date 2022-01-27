using UnityEngine;

namespace Bloodeck
{
    [CreateAssetMenu(
        fileName = "CardEffectTrigger",
        menuName = Constants.CreateAssetMenuPrefix + "Card Effect Trigger",
        order = Constants.CreateAssetMenuOrder)]
    public class CardEffectTriggerSO : ScriptableObject, ICardEffectTrigger { }
}