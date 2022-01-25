using System.Collections.Generic;

namespace Bloodeck
{
    public interface ICardEffectMap : IDictionary<ICardEffectTrigger, ICardEffects> { }
}