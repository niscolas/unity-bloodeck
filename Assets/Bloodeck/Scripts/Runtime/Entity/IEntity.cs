using System;

namespace Bloodeck
{
    public interface IEntity : IEntityData
    {
        event Action Destroyed;
        void LoadTemplate(IEntityTemplate template);
        void Destroy(IEntity instigator = null);
    }
}