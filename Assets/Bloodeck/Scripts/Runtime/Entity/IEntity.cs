using System;

namespace Bloodeck
{
    public interface IEntity : IEntityData
    {
        event Action<IEntity> Destroyed;
        void LoadTemplate(IEntityTemplate template);
        void Destroy(IEntity instigator = null);
    }
}