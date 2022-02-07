using niscolas.UnityUtils.Core;
using TMPro;
using UnityEngine;
using Zenject;

namespace Bloodeck.View
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Entity Description (TMP_Text) View")]
    public class EntityDescriptionTMPTextViewMB : CachedMB
    {
        [Inject, SerializeField]
        private EntityMB _entity;

        [SerializeField]
        private TMP_Text _text;

        private void Start()
        {
            UpdateDescription();
        }

        public void UpdateDescription()
        {
            _text.SetText(_entity.LoadedTemplate.Description);
        }
    }
}