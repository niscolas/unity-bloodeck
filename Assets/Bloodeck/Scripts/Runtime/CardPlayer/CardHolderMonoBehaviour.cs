using niscolas.UnityUtils.Core;
using UnityEngine;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Holder")]
    public class CardHolderMonoBehaviour : CachedMonoBehaviour //, ICardHolder
    {
        public ICards Cards { get; }
    }
}