using UnityEngine;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Entity Components")]
    public class EntityComponentsMonoBehaviour :
        BaseComponentsMonoBehaviour<IEntityComponent, BaseEntityComponentMonoBehaviour>, IEntityComponents { }
}