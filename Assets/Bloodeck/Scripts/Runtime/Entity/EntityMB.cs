using Creatable;
using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Entity")]
    public class EntityMB : CachedMB, IEntity
    {
        [Expandable, Creatable, SerializeField]
        private EntityTemplateSO _template;

        [Inject, SerializeField]
        private EntityComponentsMB _components;

        public IEntityComponents Components => _components;

        public string Description => _template.Description;

        public Sprite Icon => _template.Icon;

        public string Name => _template.Name;

        public EntityTemplateSO TemplateSO => _template;

        public IEntityTemplate Template
        {
            get => _template;
            set => _template = value as EntityTemplateSO;
        }


        [Inject]
        private EntityController _controller;

        public void LoadTemplate(IEntityTemplate template)
        {
            _controller.LoadTemplate(template);
        }
    }
}