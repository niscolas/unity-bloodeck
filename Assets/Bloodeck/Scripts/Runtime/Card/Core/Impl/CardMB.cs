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
        private DeployableCardMB _deployableCard;
        
        [Inject, SerializeField]
        private EntityMB _entity;

        [Header(HeaderTitles.Output)]
        [SerializeField]
        private IntReference _costOutput;

        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent _onDestroyed;

        [Header(HeaderTitles.Debug)]
        [SerializeField]
        private CardPlayerMB _owner;

        [SerializeField]
        private CardTemplateSO _loadedTemplate;
        
        public event Action Destroyed;

        public int Cost
        {
            get => _costOutput.Value;
            set => _costOutput.Value = value;
        }

        public IDeployableCard Deployable => _deployableCard;
        
        public IEntity SelfEntity => _entity;

        public ICardSlot Slot => _deployableCard.Slot;
        
        public ICardEffectMap Effects => _loadedTemplate.Effects;

        public ICardPlayer Owner
        {
            get => _owner;
            set => _owner = value as CardPlayerMB;
        }

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
            OnTemplateLoaded();
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
            SyncCostWithTemplate();
            SyncGameObjectNameWithTemplate();
        }

        private void SyncCostWithTemplate()
        {
            Cost = _loadedTemplate.Cost;
        }

        private void SyncGameObjectNameWithTemplate()
        {
            name = $"Card-{_loadedTemplate.SelfEntityTemplate.Name}";
        }
        
    }
}