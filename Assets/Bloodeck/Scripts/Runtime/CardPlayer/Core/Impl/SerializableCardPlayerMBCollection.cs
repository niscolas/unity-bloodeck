using System;
using System.Collections.Generic;
using niscolas.UnityUtils.Core;

namespace Bloodeck
{
    [Serializable]
    public class SerializableCardPlayerMBCollection :
        MBCollection<ICardPlayer, CardPlayerMB>, ICardPlayers { }
}