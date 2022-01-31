using System.Collections.Generic;
using System.Linq;
using niscolas.UnityUtils.Core;
#if UNITY_EDITOR
using niscolas.UnityUtils.Core.Editor;
#endif
using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;

namespace Bloodeck
{
    public abstract class AssetDatabaseMB<T> : CachedMB, IPrepare where T : Object
    {
        [SerializeField]
        private bool _autoGatherAssets = true;

        [SerializeField]
        private List<T> _content = new List<T>();

        public List<T> Content => _content;

        public bool Prepare()
        {
#if UNITY_EDITOR
            if (!_autoGatherAssets)
            {
                return false;
            }

            IEnumerable<T> assets = AssetDatabaseUtility.FindAllAssetsOfType<T>().ToArray();
            if (assets.ElementsAreEqual(_content))
            {
                return false;
            }

            _content.Clear();
            _content.AddRange(assets);
            return true;
#endif
            return false;
        }

        public static implicit operator T[](AssetDatabaseMB<T> database)
        {
            return database._content.ToArray();
        }
    }
}