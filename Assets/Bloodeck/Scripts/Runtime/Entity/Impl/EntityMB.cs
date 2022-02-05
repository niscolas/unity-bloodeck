using System;
using Creatable;
using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Entity")]
    public class EntityMB : CachedMB, IEntity, IEntityHumbleObject
    {
        [Expandable, Creatable, SerializeField]
        private EntityTemplateSO _templateToLoad;

        [Inject, SerializeField]
        private EntityComponentsMB _components;

        [Header(HeaderTitles.Debug)]
        [ReadOnly, SerializeField]
        private EntityTemplateSO _loadedTemplate;

        public IEntityComponents Components => _components;

        public string Description => _loadedTemplate.Description;

        public Sprite Icon => _loadedTemplate.Icon;

        public string Name => _loadedTemplate.Name;

        public IEntityTemplate LoadedTemplate => _loadedTemplate;

        public EntityTemplateSO TemplateSO => _loadedTemplate;

        [Inject]
        private EntityController _controller;

        private void Start()
        {
            if (CheckShouldLoadTemplate())
            {
                LoadTemplateToLoad();
            }
        }

        public void LoadTemplate(IEntityTemplate template)
        {
            _controller.LoadTemplate(template);
        }

        public void SetLoadedTemplate(IEntityTemplate template)
        {
            _loadedTemplate = template as EntityTemplateSO;
        }

        private void LoadTemplateToLoad()
        {
            LoadTemplate(_templateToLoad);
        }

        private bool CheckShouldLoadTemplate()
        {
            return _templateToLoad && _templateToLoad != _loadedTemplate;
        }
    }
}