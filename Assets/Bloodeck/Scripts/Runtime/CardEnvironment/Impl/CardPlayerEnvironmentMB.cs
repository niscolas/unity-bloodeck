using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Player Environment")]
    public class CardPlayerEnvironmentMB : CachedMB, ICardPlayerEnvironment
    {
        [Inject, SerializeReference, SubclassSelector]
        private ICardSlots _slots;

        public ICardSlots Slots => _slots;
    }
}