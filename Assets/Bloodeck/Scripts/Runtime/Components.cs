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

        public void Add<T>(T componentInstance) where T : TComponent
        {
            _content.Add(typeof(T), componentInstance);
        }

        public bool TryGet<T>(out T value) where T : class, TComponent
        {
            bool result = _content.TryGetValue(typeof(T), out TComponent foundComponent);
            value = foundComponent as T;

            return result;
        }
    }
}