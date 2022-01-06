﻿using System;
using Healthy;
using Zenject;

namespace Bloodeck
{
    public class EntityHealthProxy : IEntityHealth, IHealth
    {
        public bool CanHeal { get; set; } = true;

        public bool CanTakeDamage { get; set; } = true;

        float IHealth.Current
        {
            get => Current;
            set => Current = EntityHealthController.FormatHealthValue(value);
        }

        public int Current { get; set; }

        [Inject]
        public IHealth Health { get; private set; }

        float IHealth.Max
        {
            get => Max;
            set => Max = EntityHealthController.FormatHealthValue(value);
        }

        public int Max { get; set; }

        float IHealth.Min
        {
            get => Min;
            set => Min = EntityHealthController.FormatHealthValue(value);
        }

        public int Min { get; set; }

        public IEntity SelfEntity { get; }

        private readonly EntityHealthController _controller;

        public EntityHealthProxy(
            IEntity selfEntity,
            int current = 0,
            int max = 0,
            int min = default)
        {
            _controller = new EntityHealthController(this);

            SelfEntity = selfEntity;
            Current = current;
            Max = max;
            Min = min;
        }

        public void Heal(
            float healValue,
            object instigator = null,
            Action<(float, float)> healedWithHistoryCallback = null,
            Action revivedCallback = null)
        {
            _controller.Heal(healValue, instigator, healedWithHistoryCallback, revivedCallback);
        }

        public void Heal(int healValue, IEntity instigator = null)
        {
            _controller.Heal(healValue, instigator);
        }

        public void TakeDamage(
            float damageValue,
            object instigator = null,
            Action<(float, float)> damageTakenWithHistoryCallback = null,
            Action deathCallback = null)
        {
            _controller.TakeDamage(damageValue, instigator, damageTakenWithHistoryCallback, deathCallback);
        }

        public void TakeDamage(int damageValue, IEntity instigator = null)
        {
            _controller.TakeDamage(damageValue, instigator);
        }
    }
}