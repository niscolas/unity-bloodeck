using System;
using Lingua;
using NaughtyAttributes;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [Serializable]
    public class SerializableEntityTemplate : IEntityTemplate
    {
        [ShowAssetPreview(Constants.AssetPreviewSize, Constants.AssetPreviewSize)]
        [SerializeField]
        private Sprite _icon;

        [Inject(Id = ZenjectIds.TextFieldId), SerializeReference, SubclassSelector]
        private INoContextText _name;

        [Inject, SerializeReference, SubclassSelector]
        private INoContextText _description;

        [SerializeReference, SubclassSelector]
        private IEntityComponentTemplates _components;

        public IEntityComponentTemplates ComponentTemplates => _components;

        public Sprite Icon => _icon;

        public string Name => _name.Get();

        public string Description => _description.Get();
    }
}