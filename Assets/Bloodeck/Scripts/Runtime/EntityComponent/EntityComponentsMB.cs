using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Entity Components")]
    public class EntityComponentsMB : ParentCollectionMB<IEntityComponent, EntityComponentMB>, IEntityComponents
    {
        public bool TryGet<T>(out T value) where T : IEntityComponent
        {
            return _content.TryGetFirstOfType(out value);
        }
    }
}