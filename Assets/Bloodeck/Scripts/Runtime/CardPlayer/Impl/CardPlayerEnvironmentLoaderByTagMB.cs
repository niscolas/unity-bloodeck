using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Player Environment Loader by Tag")]
    public class CardPlayerEnvironmentLoaderByTagMB : CachedMB
    {
        [SerializeField]
        private StringReference _targetEnvironmentTag;

        public string TargetEnvironmentTag => _targetEnvironmentTag.Value;
    }
}