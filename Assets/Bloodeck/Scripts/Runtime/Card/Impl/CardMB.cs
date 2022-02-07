using System;
using Creatable;
using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card")]
    public class CardMB : CachedMB, ICard, ICardHumbleObject, ITemplatable<CardTemplateSO>
    {
        [Expandable, Creatable, SerializeField]
        private CardTemplateSO _templateToLoad;

        [Inject, SerializeField]
        private EntityMB _entity;

        [Inject, SerializeField]
        private CardComponentsMB _components;

        [Header(HeaderTitles.Output)]
        [SerializeField]
        private IntReference _costOutput;

        [Header(HeaderTitles.Debug)]
        [ReadOnly, SerializeField]
        private CardTemplateSO _loadedTemplate;

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
        private CardController _controller;

        private ICard _asICard;

        protected override void Awake()
        {
            base.Awake();
            _asICard = this;
        }

        private void Start()
        {
            SimpleTemplateLoader<CardTemplateSO>.InitializationLoadTemplate(this);
        }

        public void LoadTemplate(ICardTemplate template)
        {
            _controller.LoadTemplate(template);
            UpdateCost();
        }

        public void SetHumbleObjectLoadedTemplate(ICardTemplate template)
        {
            _loadedTemplate = template as CardTemplateSO;
        }

        public void LoadTemplate(CardTemplateSO template)
        {
            _asICard.LoadTemplate(template);
        }

        private void UpdateCost()
        {
            _costOutput.Value = _loadedTemplate.Cost;
        }
    }
}