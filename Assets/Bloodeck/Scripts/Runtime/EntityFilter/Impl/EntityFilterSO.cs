using System.Collections.Generic;
using UnityEngine;

namespace Bloodeck
{
    [CreateAssetMenu(
        fileName = "EntityFilter",
        menuName = Constants.CreateAssetMenuPrefix + "Entity Filter",
        order = Constants.CreateAssetMenuOrder)]
    public class EntityFilterSO : ScriptableObject, IEntityFilter
    {
        public IEnumerable<IEntityFilter> Filter(IEnumerable<IEntityFilter> entities)
        {
            throw new System.NotImplementedException();
        }
    }
}