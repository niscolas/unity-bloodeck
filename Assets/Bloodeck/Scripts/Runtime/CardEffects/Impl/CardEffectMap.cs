using System;
using SerializableDictionary;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public class CardEffectMap :
        FullSerializeReferenceSerializableDictionary<ICardEffectTrigger, ICardEffects>,
        ICardEffectMap
    {
        protected override ICardEffectTrigger GetDefaultKey()
        {
            return ScriptableObject.CreateInstance<CardEffectTriggerSO>();
        }
    }
    
    [Serializable]
    public class TestDict :
        FullSerializeReferenceSerializableDictionary<ICardEffectTrigger, IEntity>
    {
        protected override ICardEffectTrigger GetDefaultKey()
        {
            return ScriptableObject.CreateInstance<CardEffectTriggerSO>();
        }
    }
}