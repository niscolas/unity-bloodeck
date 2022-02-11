using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    public class CardEffectTriggererMB : CachedMB
    {
        [Header(HeaderTitles.Injections)]
        [Inject(Id = ZenjectIds.AllEntitiesId), SerializeReference]
        private IEntities _allEntities;

        [Inject, SerializeField]
        private CardMB _selfCard;

        public void Trigger(CardEffectTriggerSO trigger)
        {
            _selfCard.Effects.Trigger(trigger, _allEntities, _selfCard);
        }
    }
}