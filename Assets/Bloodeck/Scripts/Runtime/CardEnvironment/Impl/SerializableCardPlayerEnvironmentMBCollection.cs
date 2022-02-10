using System;
using System.Collections.Generic;
using niscolas.UnityUtils.Core;

namespace Bloodeck
{
    [Serializable]
    public class SerializableCardPlayerEnvironmentMBCollection :
        MBCollection<ICardPlayerEnvironment, CardPlayerEnvironmentMB>,
        ICardPlayerEnvironments, ICardPlayerEnvironmentMBCollection
    {
        public SerializableCardPlayerEnvironmentMBCollection() { }
        public SerializableCardPlayerEnvironmentMBCollection(IEnumerable<CardPlayerEnvironmentMB> content) : base(content) { }
        public SerializableCardPlayerEnvironmentMBCollection(params CardPlayerEnvironmentMB[] content) : base(content) { }
    }
}