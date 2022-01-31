using System;
using niscolas.UnityUtils.SerializeReference;

namespace Bloodeck
{
    [Serializable]
    public class SerializableEntityFilters : SerializeReferenceCollection<IEntityFilter>, IEntityFilters { }
}