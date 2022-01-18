using UnityEngine;

namespace Bloodeck
{
    public interface IEntityTemplateData
    {
        IEntityComponentTemplates ComponentTemplates { get; }

        string Description { get; }

        Sprite Icon { get; }

        string Name { get; }
    }
}