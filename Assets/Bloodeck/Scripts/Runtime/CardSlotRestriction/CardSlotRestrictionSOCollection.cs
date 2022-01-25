using System;
using System.Linq;
using niscolas.UnityUtils.Core;

namespace Bloodeck
{
    [Serializable]
    public class CardSlotRestrictionSOCollection :
        ParentCollection<ICardSlotRestriction, CardSlotRestrictionSO>, ICardSlotRestrictions
    {
        public bool Validate(ICard card)
        {
            return _content.All(x => x.Validate(card));
        }
    }
}