using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    public abstract class BaseCardComponentMonoBehaviour : CachedMonoBehaviour, ICardComponent
    {
        [Inject, SerializeField]
        protected CardMonoBehaviour _owner;

        public ICard Owner => _owner;
    }
}