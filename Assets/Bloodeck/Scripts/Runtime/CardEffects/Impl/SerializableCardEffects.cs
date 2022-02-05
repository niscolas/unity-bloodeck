using System;
using niscolas.UnityUtils.SerializeReference;

namespace Bloodeck
{
    [Serializable]
    public class SerializableCardEffects : SerializeReferenceCollection<ICardEffect>, ICardEffects { }
}