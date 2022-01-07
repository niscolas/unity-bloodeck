using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    public abstract class BaseEntityComponentMonoBehaviour : CachedMonoBehaviour, IEntityComponent
    {
        [Inject, SerializeField]
        protected EntityMonoBehaviour _owner;

        public IEntity Owner => _owner;
    }
}