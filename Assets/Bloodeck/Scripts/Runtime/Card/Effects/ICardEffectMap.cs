using System.Collections.Generic;

namespace Bloodeck
{
    public interface ICardEffectMap
    {
        bool TryGetValue(ICardEffectTrigger key, out ICardEffects value);
        void Trigger(ICardEffectTrigger trigger, IEnumerable<IEntity> rawTargets, ICard card);
    }
}