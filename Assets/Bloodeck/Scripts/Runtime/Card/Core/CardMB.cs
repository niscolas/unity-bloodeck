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

        public CardTemplateSO Template => _template;

        [Inject]
        private CardController _controller;

        private void Start()
        {
            _costOutput.Value = _template.Cost;
        }
    }
}