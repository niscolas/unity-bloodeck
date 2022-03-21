using System;
using UnityEngine;

namespace Bloodeck
{
    public class EntityController : IEntity
    {
        public event Action<IEntity> Destroyed;

        public IEntityComponents Components => _humbleObject.Components;

        public string Description => _humbleObject.Description;

        public Sprite Icon => _humbleObject.Icon;

        public string Name => _humbleObject.Name;

        public IEntityTemplate LoadedTemplate => _humbleObject.LoadedTemplate;

        public ITeam Team
        {
            get => _humbleObject.Team;
            set => _humbleObject.Team = value;
        }

        public bool IsActiveInGame => _humbleObject.IsActiveInGame;

        private readonly IEntityHumbleObject _humbleObject;

        public EntityController(IEntityHumbleObject humbleObject)
        {
            _humbleObject = humbleObject;
        }

        public void LoadTemplate(IEntityTemplate template)
        {
            SetTemplate(template);
        }

        public void Destroy(IEntity instigator)
        {
            NotifyDestroyed(instigator);
        }

        private void SetTemplate(IEntityTemplate template)
        {
            _humbleObject.SetHumbleObjectLoadedTemplate(template);
        }

        private void NotifyDestroyed(IEntity instigator)
        {
            Destroyed?.Invoke(instigator);
        }
    }
}