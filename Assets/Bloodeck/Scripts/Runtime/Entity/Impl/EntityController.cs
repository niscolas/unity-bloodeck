using UnityEngine;

namespace Bloodeck
{
    public class EntityController : IEntity
    {
        public IEntityComponents Components => _humbleObject.Components;

        public string Description => _humbleObject.Description;

        public Sprite Icon => _humbleObject.Icon;

        public string Name => _humbleObject.Name;

        public IEntityTemplate Template
        {
            get => _humbleObject.Template;
            set => _humbleObject.Template = value;
        }

        private readonly IEntityData _humbleObject;

        public EntityController(IEntityData humbleObject)
        {
            _humbleObject = humbleObject;
        }

        public void LoadTemplate(IEntityTemplate template)
        {
            Template = template;
        }
    }
}