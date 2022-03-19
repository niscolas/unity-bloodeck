using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    public abstract class EntityComponentMB : CachedMB, IEntityComponent
    {
        [SerializeField]
        private BoolReference _visibleByEntityComponents = new BoolReference(true);

        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        protected EntityMB _ownerEntity;

        public IEntity OwnerEntity => _ownerEntity;

        public bool VisibleByEntityComponents => _visibleByEntityComponents.Value;
    }
}