using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Entity Components")]
    public class EntityComponentsMB :
        InjectableParentCollectionMB<IEntityComponent, EntityComponentMB>,
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