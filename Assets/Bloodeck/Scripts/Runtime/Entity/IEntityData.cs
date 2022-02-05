using UnityEngine;

namespace Bloodeck
{
    public interface IEntityData
    {
        IEntityComponents Components { get; }

        string Description { get; }

        Sprite Icon { get; }

        string Name { get; }

        IEntityTemplate LoadedTemplate { get; }
    }
}