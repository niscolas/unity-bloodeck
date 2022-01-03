using Lingua;
using NaughtyAttributes;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [CreateAssetMenu(
        fileName = DisplayName,
        menuName = Constants.CreateAssetMenuPrefix + DisplayName,
        order = Constants.CreateAssetMenuOrder)]
    public class EntityTemplateSO : ScriptableObject
    {
        private const string DisplayName = "Entity";
        
        [ShowAssetPreview(Constants.AssetPreviewSize, Constants.AssetPreviewSize)]
        [SerializeField]
        private Sprite _icon;

        [Inject(Id = ZenjectIds.TextFieldId), SerializeReference]
        private INoContextText _name;

        [Inject, SerializeReference]
        private INoContextText _description;
        
        [SerializeField]
        private IntReference _maxHealth = new IntReference(1);
    }
}