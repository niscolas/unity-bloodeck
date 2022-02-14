using System.Collections.Generic;

namespace Bloodeck
{
    public interface IDeckHumbleObject : IDeckData, ITemplateHumbleObject<IDeckTemplate>
    {
        IList<ICard> Cards { get; }
    }
}