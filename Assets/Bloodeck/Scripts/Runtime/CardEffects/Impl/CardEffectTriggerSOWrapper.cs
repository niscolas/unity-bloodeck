using System;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public struct CardEffectTriggerSOWrapper : ICardEffectTrigger
    {
        [SerializeField]
        private CardEffectTriggerSO _trigger;

        public override bool Equals(object obj)
        {
            if (obj is CardEffectTriggerSOWrapper otherWrapper)
            {
                return _trigger == otherWrapper._trigger;
            }
            else if (obj is CardEffectTriggerSO otherTrigger)
            {
                return _trigger == otherTrigger;
            }

            return false;
        }
    }
}