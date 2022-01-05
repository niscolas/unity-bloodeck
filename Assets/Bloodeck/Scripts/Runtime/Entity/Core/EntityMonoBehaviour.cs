using System;
using Creatable;
using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [Serializable]
    public class EntityMonoBehaviour : CachedMonoBehaviour, IEntity
    {
        [Expandable, Creatable, SerializeField]
        private EntityTemplateSO _template;
            
        public IEntityComponents Components { get; }
        
        public string Name => _template.Name;

        [Inject]
        private EntityController _controller;
    }
}