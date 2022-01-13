using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    public abstract class BaseCardComponentMB : CachedMB, ICardComponent
    {
        [Inject, SerializeField]
        protected CardMB _owner;

        public ICard Owner => _owner;
    }
}