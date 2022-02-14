using System;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public class CardEffectTriggerSOWrapper : ICardEffectTrigger, IEquatable<CardEffectTriggerSOWrapper>
    {
        [SerializeField]
        private CardEffectTriggerSO _trigger;

        public override bool Equals(object obj)
        {
            if (obj is CardEffectTriggerSOWrapper otherWrapper)
            {
                return _trigger == otherWrapper._trigger;
            }

            if (obj is CardEffectTriggerSO otherTrigger)
            {
                return _trigger == otherTrigger;
            }

            return false;
        }

        public bool Equals(CardEffectTriggerSOWrapper other)
        {
            return Equals(_trigger, other._trigger);
        }

        public override int GetHashCode()
        {
            return _trigger != null ? _trigger.GetHashCode() : 0;
        }
    }
}