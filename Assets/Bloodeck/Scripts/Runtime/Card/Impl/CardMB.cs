using Creatable;
using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card")]
    public class CardMB : CachedMB, ICard
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

        public ICardTemplate Template
        {
            get => _loadedTemplate;
            set => _loadedTemplate = value as CardTemplateSO;
        }

        public CardTemplateSO TemplateSO => _loadedTemplate;

        [Inject]
        private CardController _controller;

        private bool _hasAwakened;

        protected override void Awake()
        {
            base.Awake();

            if (CheckHasTemplateToLoad())
            {
                Internal_LoadTemplate(_templateToLoad);
            }

            _hasAwakened = true;
        }

        public void LoadTemplate(ICardTemplate template)
        {
            if (_hasAwakened)
            {
                Internal_LoadTemplate(template);
            }
            else
            {
                _templateToLoad = (CardTemplateSO) template;
            }
        }

        private bool CheckHasTemplate()
        {
            return _loadedTemplate;
        }

        private bool CheckHasTemplateToLoad()
        {
            return !_templateToLoad.IsUnityNull();
        }

        private void Internal_LoadTemplate(ICardTemplate template)
        {
            _controller.LoadTemplate(template);
            UpdateCost();
        }

        private void UpdateCost()
        {
            _costOutput.Value = _loadedTemplate.Cost;
        }
    }
}