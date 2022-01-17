using niscolas.UnityUtils.Core;
using TMPro;
using UnityEngine;
using Zenject;

namespace Bloodeck.View
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Entity Name TMP_Text View")]
    public class EntityNameTMPTextViewMB : CachedMB
    {
        [Inject, SerializeField]
        private EntityMB _entity;

        [SerializeField]
        private TMP_Text _text;

        private void Start()
        {
            UpdateName();
        }

        public void UpdateName()
        {
            _text.SetText(_entity.TemplateSO.Name);
        }
    }
}