using System;
using System.Collections.Generic;
using Zenject;

namespace Bloodeck
{
    public class Components<TComponent> : IComponents<TComponent>
    {
        private readonly IDictionary<Type, TComponent> _content;

        [Inject]
        public Components(IDictionary<Type, TComponent> content)
        {
            _content = content;
        }

        public void Add<T>(T componentInstance) where T : class, TComponent
        {
            _content.Add(typeof(T), componentInstance);
        }

        public bool TryGet<T>(out T value) where T : class, TComponent
        {
            value = default;
            bool result = _content.TryGetValue(typeof(T), out TComponent foundComponent);
            if (result)
            {
                value = foundComponent as T;
            }

            return result;
        }
    }
}