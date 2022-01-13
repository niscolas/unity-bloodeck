using UnityEngine;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Entity Components")]
    public class EntityComponentsMB :
        BaseComponentsMB<IEntityComponent, BaseEntityComponentMB>, IEntityComponents { }
}