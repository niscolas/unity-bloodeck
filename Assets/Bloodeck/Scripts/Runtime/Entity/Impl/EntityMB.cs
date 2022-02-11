using System;
using System.Linq;
using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
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
        [SerializeField]
        private TeamTypeSO _team;

        [SerializeReference]
        private IEntityTemplate _loadedTemplate;

        [ShowNativeProperty]
        private int _allEntitiesCountDebug => GetAllEntitiesCount();

        public IEntityComponents Components => _components;

        public string Description => _loadedTemplate.Description;

        public Sprite Icon => _loadedTemplate.Icon;

        public string Name => _loadedTemplate.Name;

        public IEntityTemplate TemplateToLoad => _templateToLoad;

        public IEntityTemplate LoadedTemplate => _loadedTemplate;

        public ITeam Team => _team;

        [Inject]
        private EntityController _controller;

        [Inject(Id = ZenjectIds.AllEntitiesId)]
        private IEntities _allEntities;

        private void Start()
        {
            SimpleTemplateLoader<IEntityTemplate>.InitializationLoadTemplate(this);
            _allEntities.Add(this);
        }

        private void OnDestroy()
        {
            _allEntities.Remove(this);
        }

        public void LoadTemplate(IEntityTemplate template)
        {
            _controller.LoadTemplate(template);
        }

        public void SetHumbleObjectLoadedTemplate(IEntityTemplate template)
        {
            _loadedTemplate = template;
        }

        private int GetAllEntitiesCount()
        {
            if (_allEntities.IsNullOrEmpty())
            {
                return 0;
            }

            return _allEntities.Count;
        }
    }
}