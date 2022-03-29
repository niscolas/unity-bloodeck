using System;
using System.Collections.Generic;
using System.Linq;

namespace Bloodeck
{
    [Serializable]
    public class CardsOnlyEntityFilter : IEntityFilter
    {
        public IEnumerable<IEntity> Filter(IEnumerable<IEntity> entities, IEntity instigator = null)
        {
            entities = entities.Where(x =>
            {
                if (!x.IsActiveInGame)
                {
                    return false;
                }

                bool isCard = x.Components.TryGet(out CardEntityLinkComponentMB _);
                return isCard;
            });
            return entities;
        }
    }
}