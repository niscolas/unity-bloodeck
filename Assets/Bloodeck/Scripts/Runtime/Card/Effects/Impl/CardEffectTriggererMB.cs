using System;
using System.Collections.Generic;
using System.Linq;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
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

        public static List<CardEffectTriggererMB> Triggerers =
            new List<CardEffectTriggererMB>();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void RuntimeInit()
        {
            Triggerers.Clear();
        }

        private void OnEnable()
        {
            Triggerers.Add(this);
        }

        private void OnDisable()
        {
            Triggerers.Remove(this);
        }

        public void GlobalTrigger(CardEffectTriggerSO trigger)
        {
            IEnumerable<CardEffectTriggererMB> triggerers = Triggerers
                .Where(x => 
                    x._selfCard.SelfEntity.IsActiveInGame && x != this);

            Trigger(triggerers.ToArray(), trigger);
        }

        public void GlobalTriggerWithSelf(CardEffectTriggerSO trigger)
        {
            Trigger(Triggerers.ToArray(), trigger);
        }

        public static void Trigger(
            CardEffectTriggererMB[] triggerers,
            CardEffectTriggerSO trigger)
        {
            triggerers.ForEach(x => x.Trigger(trigger));
        }

        public void Trigger(CardEffectTriggerSO trigger)
        {
            _selfCard.Effects.Trigger(trigger, GetFilteredEntities(), _selfCard);
        }

        private IEnumerable<IEntity> GetFilteredEntities()
        {
            return _allEntities;
        }
    }
}