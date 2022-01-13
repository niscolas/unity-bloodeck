using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Bloodeck.View
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Entity Icon Sprite View")]
    public class EntityIconSpriteRendererViewMB : CachedMB
    {
        [Inject, SerializeField]
        private EntityMB _entity;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            UpdateIcon();
        }

        public void UpdateIcon()
        {
            _spriteRenderer.sprite = _entity.Template.Icon;
        }
    }
}