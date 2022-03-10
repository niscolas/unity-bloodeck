using System;
using System.Collections.Generic;
using SerializableDictionary;

namespace Bloodeck
{
    [Serializable]
    public class SerializableCardEffectMap :
        FakeSerializableDictionary<ICardEffectTrigger, ICardEffects,
            SerializeReferenceKeyValuePair<ICardEffectTrigger, ICardEffects>>,
        ICardEffectMap
    {
        public void Trigger(ICardEffectTrigger trigger, IEnumerable<IEntity> rawTargets, ICard card)
        {
            if (!TryGetValue(trigger, out ICardEffects effects))
            {
                return;
            }

            effects.Trigger(rawTargets, card);
        }
    }
}