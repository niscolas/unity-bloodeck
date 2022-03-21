using System;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Entity")]
    public class EntityMB : CachedMB, IEntity, IEntityHumbleObject, ITemplatable<IEntityTemplate>
    {
        [SerializeReference]
        private IEntityTemplate _templateToLoad;

        [SerializeField]
        private BoolReference _isActiveInGame;

        [Header(HeaderTitles.Debug)]
        [SerializeField]
        private TeamTypeSO _team;

        [SerializeReference]
        private IEntityTemplate _loadedTemplate;

        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private EntityComponentsMB _components;

        [Inject(Id = ZenjectIds.AllEntitiesId), SerializeField]
        private ParentCollection<IEntity, EntityMB> _allEntities;

        public event Action<IEntity> Destroyed;

        public IEntityComponents Components => _components;

        public string Description => _loadedTemplate.Description;

        public Sprite Icon => _loadedTemplate.Icon;

        public string Name => _loadedTemplate.Name;

        public IEntityTemplate TemplateToLoad => _templateToLoad;

        public IEntityTemplate LoadedTemplate => _loadedTemplate;

        public ITeam Team
        {
            get => _team;
            set => _team = value as TeamTypeSO;
        }

        public bool IsActiveInGame => _isActiveInGame.Value;

        [Inject]
        private EntityController _controller;

        [Inject]
        private IDespawnService _despawnService;

        protected override void Awake()
        {
            base.Awake();
            _controller.Destroyed += OnDestroyed;
        }

        private void OnEnable()
        {
            _allEntities.Add(this);
        }

        private void Start()
        {
            SimpleTemplateLoader<IEntityTemplate>.InitializationLoadTemplate(this);
        }

        private void OnDisable()
        {
            _allEntities.Remove(this);
        }

        public void LoadTemplate(IEntityTemplate template)
        {
            _controller.LoadTemplate(template);
            OnTemplateLoaded();
        }

        public void Destroy(IEntity instigator = null)
        {
            _controller.Destroy(instigator);
            _despawnService.Despawn(_gameObject);
        }

        public void SetHumbleObjectLoadedTemplate(IEntityTemplate template)
        {
            _loadedTemplate = template;
        }

        private void OnTemplateLoaded()
        {
            CallTemplateNotifierCallbackReceivers();
        }

        private void CallTemplateNotifierCallbackReceivers()
        {
            GetComponentsInChildren<IEntityTemplateLoadedCallbackReceiver>()
                .ForEach(x => x.OnEntityTemplateLoaded());
        }

        private int GetAllEntitiesCount()
        {
            if (_allEntities.IsNullOrEmpty())
            {
                return 0;
            }

            return _allEntities.Count;
        }

        private void OnDestroyed(IEntity instigator)
        {
            Destroyed?.Invoke(instigator);
        }
    }
}