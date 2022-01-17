﻿namespace Bloodeck
{
    public class EntityController : IEntity
    {
        public IEntityComponents Components => _humbleObject.Components;

        public string Name => _humbleObject.Name;

        public IEntityTemplate Template => _humbleObject.Template;

        private readonly IEntityData _humbleObject;

        public EntityController(IEntityData humbleObject)
        {
            _humbleObject = humbleObject;
        }
    }
}