using Creatable;
using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card")]
    public class CardMonoBehaviour : CachedMonoBehaviour, ICard
    {
        [Expandable, Creatable, SerializeField]
        private CardTemplateSO _template;

        [Inject, SerializeField]
        private EntityMonoBehaviour _entity;

        public ICardComponents Components { get; }
        
        public int Cost => _template.Cost;
        
        public IEntity SelfEntity => _entity;

        public CardTemplateSO Template => _template;

        [Inject]
        private CardController _controller;
    }
}