using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Bloodeck.View
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Entity Icon (Image) View")]
    public class EntityIconImageViewMB : CachedMB
    {
        [Inject, SerializeField]
        private EntityMB _entity;

        [SerializeField]
        private Image _image;

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