using System;
using SerializableDictionary;

namespace Bloodeck
{
    [Serializable]
    public class CardEffectMap :
        FullSerializeReferenceSerializableDictionary<ICardEffectTrigger, ICardEffects>,
        ICardEffectMap
    {
        protected override ICardEffectTrigger GetDefaultKey()
        {
            return new CardEffectTriggerSOWrapper();
        }

    }
}