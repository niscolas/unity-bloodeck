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

        [Header(HeaderTitles.Debug)]
        [Inject(Id = ZenjectIds.AllEntitiesId), SerializeField]
        private ParentCollection<IEntity, EntityMB> _allEntities;

        public void Trigger(CardEffectTriggerSO trigger)
        {
            _selfCard.Effects.Trigger(trigger, _allEntities, _selfCard);
        }
    }
}