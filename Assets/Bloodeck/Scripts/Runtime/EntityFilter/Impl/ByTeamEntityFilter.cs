using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public class ByTeamEntityFilter : IEntityFilter
    {
        [SerializeField]
        private TeamTypeSO _team;
        
        public IEnumerable<IEntity> Filter(IEnumerable<IEntity> entities, IEntity instigator = null)
        {
            IEnumerable<IEntity> filteredEntities = entities
                .Where(x => ReferenceEquals(_team, x.Team));
            return new SerializableEntities(filteredEntities);
        }
    }
}