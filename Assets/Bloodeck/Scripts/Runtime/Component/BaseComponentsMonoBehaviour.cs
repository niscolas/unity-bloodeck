using System.Collections.Generic;
using System.Linq;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    public abstract class BaseComponentsMonoBehaviour<TComponent, TMonoBehaviourComponent> :
        CachedMonoBehaviour, IComponents<TComponent>
        where TMonoBehaviourComponent : class, TComponent, IComponent
    {
        [Inject, SerializeReference]
        private List<TMonoBehaviourComponent> _content;

        public virtual void Add<T>(T componentInstance) where T : class, TComponent
        {
            _content.Add(componentInstance as TMonoBehaviourComponent);
        }

        public virtual bool TryGet<T>(out T value) where T : class, TComponent
        {
            value = default;

            TMonoBehaviourComponent component = _content.FirstOrDefault(e => e.GetType() == typeof(T));

            bool foundComponent = !component.IsUnityNull();
            if (foundComponent)
            {
                value = component as T;
            }

            return foundComponent;
        }
    }
}