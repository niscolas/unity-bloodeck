using System;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;

namespace Bloodeck
{
    public class EntityComponentsMB :
        ParentCollectionMB<IEntityComponent, EntityComponentMB>,
        IEntityComponents,
        IEntityTemplateLoadedCallbackReceiver
    {
        public void OnEntityTemplateLoaded()
        {
            LoadComponents();
        }

        public bool TryGet<T>(out T value) where T : IEntityComponent
        {
            return _content.TryGetFirstOfType(out value);
        }

        public bool TryGet(Type type, out IEntityComponent value)
        {
            return _content.TryGetFirstOfType(type, out value);
        }

        public void LoadComponents()
        {
            _content.ForEach(x =>
            {
                if (x is IEntityComponentWithTemplate componentWithTemplate)
                {
                    componentWithTemplate.LoadCurrentTemplate();
                }
            });
        }
    }
}