using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Entity")]
    public class EntityMB : CachedMB, IEntity, IEntityHumbleObject, ITemplatable<IEntityTemplate>
    {
        [SerializeReference]
        private IEntityTemplate _templateToLoad;

        [Inject, SerializeField]
        private EntityComponentsMB _components;

        [Header(HeaderTitles.Debug)]
        [ReadOnly, SerializeReference]
        private IEntityTemplate _loadedTemplate;

        public IEntityComponents Components => _components;

        public string Description => _loadedTemplate.Description;

        public Sprite Icon => _loadedTemplate.Icon;

        public string Name => _loadedTemplate.Name;

        public IEntityTemplate TemplateToLoad => _templateToLoad;

        public IEntityTemplate LoadedTemplate => _loadedTemplate;

        [Inject]
        private EntityController _controller;

        private void Start()
        {
            SimpleTemplateLoader<IEntityTemplate>.InitializationLoadTemplate(this);
        }

        public void LoadTemplate(IEntityTemplate template)
        {
            _controller.LoadTemplate(template);
        }

        public void SetHumbleObjectLoadedTemplate(IEntityTemplate template)
        {
            _loadedTemplate = template;
        }
    }
}