using UnityEngine;

namespace Bloodeck
{
    public struct DefaultEntityData : IEntityData
    {
        public IEntityComponents Components { get; }

        public string Description { get; }

        public Sprite Icon { get; }

        public string Name { get; }

        public IEntityTemplate Template { get; set; }

        public DefaultEntityData(
            IEntityComponents components,
            IEntityTemplate template,
            string name = "",
            string description = "",
            Sprite icon = default)
        {
            Components = components;
            Description = description;
            Icon = icon;
            Name = name;
            Template = template;
        }
    }
}