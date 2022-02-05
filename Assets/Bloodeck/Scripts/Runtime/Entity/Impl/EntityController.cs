using UnityEngine;

namespace Bloodeck
{
    public class EntityController : IEntity
    {
        public IEntityComponents Components => _humbleObject.Components;

        public string Description => _humbleObject.Description;

        public Sprite Icon => _humbleObject.Icon;

        public string Name => _humbleObject.Name;

        public IEntityTemplate LoadedTemplate => _humbleObject.LoadedTemplate;

        private readonly IEntityHumbleObject _humbleObject;

        public EntityController(IEntityHumbleObject humbleObject)
        {
            _humbleObject = humbleObject;
        }

        public void LoadTemplate(IEntityTemplate template)
        {
            SetTemplate(template);
        }

        private void SetTemplate(IEntityTemplate template)
        {
            _humbleObject.SetLoadedTemplate(template);
        }
    }
}