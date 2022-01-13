using Creatable;
using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Entity")]
    public class EntityMB : CachedMB, IEntity
    {
        [Expandable, Creatable, SerializeField]
        private EntityTemplateSO _template;

        [Inject, SerializeField]
        private EntityComponentsMB _components;

        public IEntityComponents Components => _components;

        public string Name => _template.Name;

        [Inject]
        private EntityController _controller;
    }
}