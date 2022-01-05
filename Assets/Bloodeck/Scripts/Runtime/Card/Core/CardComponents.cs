using System;
using System.Collections.Generic;

namespace Bloodeck
{
    public class CardComponents : Components<ICardComponent>, ICardComponents
    {
        public CardComponents(IDictionary<Type, ICardComponent> content) : base(content) { }
    }
}