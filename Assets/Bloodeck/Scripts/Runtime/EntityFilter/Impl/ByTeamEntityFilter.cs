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
            return Filter(entities, _team, instigator);
        }

        public IEnumerable<IEntity> Filter(IEnumerable<IEntity> entities, ITeam team, IEntity instigator = null)
        {
            IEnumerable<IEntity> result = entities
                .Where(x =>
                    x.IsActiveInGame &&
                    ReferenceEquals(team, x.Team));
            return result;
        }
    }
}