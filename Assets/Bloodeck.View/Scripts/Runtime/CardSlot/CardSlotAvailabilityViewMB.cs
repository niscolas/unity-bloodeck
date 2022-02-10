using niscolas.UnityUtils.Core;

namespace Bloodeck.View
{
    public abstract class CardSlotAvailabilityViewMB : CachedMB
    {
        public abstract void Check();
        public abstract void ResetState();
    }
}