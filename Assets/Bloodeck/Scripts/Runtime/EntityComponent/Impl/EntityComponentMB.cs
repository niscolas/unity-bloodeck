using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    public abstract class EntityComponentMB : CachedMB, IEntityComponent
    {
        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        protected EntityMB _ownerEntity;

        public IEntity OwnerEntity => _ownerEntity;
    }
}