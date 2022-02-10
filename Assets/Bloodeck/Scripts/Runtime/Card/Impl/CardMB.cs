using System;
using Creatable;
using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card")]
    public class CardMB : CachedMB, ICard, ICardHumbleObject, ITemplatable<CardTemplateSO>
    {
        [Expandable, Creatable, SerializeField]
        private CardTemplateSO _templateToLoad;

        [SerializeField]
        private FloatReference _destroyDelaySeconds = new FloatReference(0.5f);

        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private EntityMB _entity;

        [Inject, SerializeField]
        private CardComponentsMB _components;

        [Header(HeaderTitles.Output)]
        [SerializeField]
        private IntReference _costOutput;

        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent _onDestroyed;

        [Header(HeaderTitles.Debug)]
        [ReadOnly, SerializeField]
        private CardTemplateSO _loadedTemplate;

        public event Action Destroyed;

        public ICardComponents Components => _components;

        public int Cost
        {
            get => _controller.Cost;
            set => _controller.Cost = value;
        }

        public IEntity SelfEntity => _entity;

        public ICardTemplate LoadedTemplate => _loadedTemplate;

        public CardTemplateSO TemplateToLoad => _templateToLoad;

        CardTemplateSO ITemplatable<CardTemplateSO>.LoadedTemplate => _loadedTemplate;

        [Inject]
        private IDespawnService _despawnService;

        [Inject]
        private CardController _controller;

        private ICard _asICard;

        protected override void Awake()
        {
            base.Awake();
            _asICard = this;
        }

        private void Start()
        {
            _controller.Destroyed += OnDestroyed;
            SimpleTemplateLoader<CardTemplateSO>.InitializationLoadTemplate(this);
        }

        private void OnDestroy()
        {
            _controller.Destroyed -= OnDestroyed;
        }

        public void LoadTemplate(ICardTemplate template)
        {
            _controller.LoadTemplate(template);
            OnTemplateLoaded();
        }

        public void Destroy()
        {
            _controller.Destroy();
        }

        public void SetHumbleObjectLoadedTemplate(ICardTemplate template)
        {
            _loadedTemplate = template as CardTemplateSO;
        }

        public void LoadTemplate(CardTemplateSO template)
        {
            _asICard.LoadTemplate(template);
        }

        private void OnDestroyed()
        {
            Destroyed?.Invoke();
            _onDestroyed?.Invoke();
            _despawnService.Despawn(_gameObject, _destroyDelaySeconds.Value);
        }

        private void OnTemplateLoaded()
        {
            UpdateCost();
            UpdateGameObjectName();
        }

        private void UpdateCost()
        {
            _costOutput.Value = _loadedTemplate.Cost;
        }

        private void UpdateGameObjectName()
        {
            name = $"Card-{_loadedTemplate.SelfEntityTemplate.Name}";
        }
    }
}