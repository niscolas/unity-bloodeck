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
    public class EntityTemplateSO : ScriptableObject, IEntityTemplate
    {
        [ShowAssetPreview(Constants.AssetPreviewSize, Constants.AssetPreviewSize)]
        [SerializeField]
        private Sprite _icon;

        [Inject(Id = ZenjectIds.TextFieldId), SerializeReference]
        private INoContextText _name;

        [Inject, SerializeReference]
        private INoContextText _description;

        [SerializeField]
        private FloatReference _maxHealth = new FloatReference(1);

        public IEntityComponents Components { get; }

        public Sprite Icon => _icon;

        public string Name => _name.Get();

        public INoContextText Description => _description;

        public float MaxHealth => _maxHealth;

        private const string DisplayName = "Entity";
    }
}