using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    public class CardEffectTriggererMB : CachedMB
    {
        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private CardMB _selfCard;

        [Inject(Id = ZenjectIds.AllEntitiesId)]
        private IEntities _allEntities;

        public void Trigger(CardEffectTriggerSO trigger)
        {
            _selfCard.Effects.Trigger(trigger, _allEntities, _selfCard);
        }
    }
}