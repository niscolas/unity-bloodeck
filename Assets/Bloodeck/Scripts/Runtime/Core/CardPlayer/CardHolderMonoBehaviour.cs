using niscolas.UnityUtils.Core;
using UnityEngine;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Holder")]
    public class CardHolderMonoBehaviour : CachedMB //, ICardHolder
    {
        public ICards Cards { get; }
    }
}