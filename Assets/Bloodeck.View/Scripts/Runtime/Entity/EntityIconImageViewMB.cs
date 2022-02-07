using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Bloodeck.View
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Entity Icon (Image) View")]
    public class EntityIconImageViewMB : EntityGraphicMB
    {
        [Inject, SerializeField]
        private EntityMB _entity;

        [SerializeField]
        private Image _image;

        public override Color Color
        {
            get => _image.color;
            set => _image.color = value;
        }

        public override Sprite Sprite
        {
            get => _image.sprite;
            set => _image.sprite = value;
        }

        private void Start()
        {
            UpdateIcon();
        }

        public void UpdateIcon()
        {
            _image.sprite = _entity.LoadedTemplate.Icon;
        }
    }
}