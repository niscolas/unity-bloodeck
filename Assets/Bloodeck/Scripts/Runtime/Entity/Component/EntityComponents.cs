using System;
using System.Collections.Generic;

namespace Bloodeck
{
    public class EntityComponents : Components<IEntityComponent>, IEntityComponents
    {
        public EntityComponents(IDictionary<Type, IEntityComponent> content) : base(content) { }
    }
}