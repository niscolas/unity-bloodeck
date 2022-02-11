using System;
using SerializableDictionary;

namespace Bloodeck
{
    [Serializable]
    public class SerializableCardEffectMap :
        FakeSerializableDictionary<ICardEffectTrigger, ICardEffects, FullSerializeReferenceKeyValuePair<ICardEffectTrigger, ICardEffects>>,
        ICardEffectMap
    {
        public void Trigger(ICardEffectTrigger trigger, IEntities rawTargets, ICard card)
        {
            if (!TryGetValue(trigger, out ICardEffects effects))
            {
                return;
            }

            effects.Trigger(rawTargets, card);
        }
    }
}