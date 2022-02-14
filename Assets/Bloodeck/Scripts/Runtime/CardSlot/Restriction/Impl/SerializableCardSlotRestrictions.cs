using System;
using niscolas.UnityUtils.SerializeReference;

namespace Bloodeck
{
    [Serializable]
    public class SerializableCardSlotRestrictions :
        SerializeReferenceCollection<ICardSlotRestriction>, ICardSlotRestrictions
    {
        public bool Validate(ICard card)
        {
            if (_content.Count == 0)
            {
                return true;
            }

            return _content.TrueForAll(x => x.Validate(card));
        }
    }
}