using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;
using Zenject;

namespace Bloodeck.View
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Simple Card Manager")]
    public class SimpleCardManagerMB : CachedMB
    {
        [SerializeField]
        private CardTemplateSOCollection _templates;

        [Inject]
        private CardMBFromTemplateFactory _factory;

        private void Start()
        {
            _templates.ForEach(x => _factory.Create(x));
        }
    }
}