using Creatable;
using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card")]
    public class CardMB : CachedMB, ICard
    {
        [Expandable, Creatable, SerializeField]
        private CardTemplateSO _template;

        [Inject, SerializeField]
        private EntityMB _entity;

        [Inject, SerializeField]
        private CardComponentsMB _components;

        [Header(HeaderTitles.Output)]
        [SerializeField]
        private IntReference _costOutput;

        public ICardComponents Components => _components;

        public int Cost
        {
            get => _controller.Cost;
            set => _controller.Cost = value;
        }

        public IEntity SelfEntity => _entity;

        public ICardTemplate Template => _template;

        public CardTemplateSO TemplateSO => _template;

        [Inject]
        private CardController _controller;

        private void Start()
        {
            if (CheckHasTemplate())
            {
                UpdateCost();
            }
        }

        public void LoadTemplate(CardTemplateSO template)
        {
            _template = template;
            UpdateCost();
        }

        private bool CheckHasTemplate()
        {
            return _template;
        }

        private void UpdateCost()
        {
            _costOutput.Value = _template.Cost;
        }
    }
}