using System;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using UnityAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.UnityAtoms
{
    [DefaultExecutionOrder(+10)]
    public abstract class SaveInstancerValueMB<T, V> : CachedMB
        where V : AtomBaseVariable<T>
    {
        [SerializeField]
        private AtomBaseVariableInstancer<T, V> _instancer;

        private T _cachedValue;

        private void OnEnable()
        {
            if (!_instancer)
            {
                return;
            }

            _instancer.Value = _cachedValue;
        }

        private void Start()
        {
            _gameObject.IfUnityNullGetComponent(ref _instancer);
        }

        private void OnDisable()
        {
            if (!_instancer)
            {
                return;
            }

            _cachedValue = _instancer.Value;
        }
    }
}