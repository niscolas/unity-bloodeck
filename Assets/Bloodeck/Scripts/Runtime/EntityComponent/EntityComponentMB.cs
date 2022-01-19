﻿using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    public abstract class EntityComponentMB : CachedMB, IEntityComponent
    {
        [Inject, SerializeField]
        protected EntityMB _owner;

        public IEntity Owner => _owner;
    }
}