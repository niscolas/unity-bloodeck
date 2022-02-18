using System;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Zenject;

namespace Bloodeck.View
{
    public class AttractorMB : AutoTriggerMB
    {
        [SerializeField]
        private FloatReference _attractionSpeed = new FloatReference(10f);

        [SerializeField]
        private Transform _targetsParent;

        [SerializeField]
        private BoolReference _disableOnAttracted = new BoolReference();

        [Inject]
        private IUnityTimeService _timeService;

        private void Start()
        {
            if (!_targetsParent)
            {
                _targetsParent = _transform;
            }
        }

        public override void Do()
        {
            _targetsParent.ForEachChildren(x => UpdateTransform(x.transform));
        }

        private void UpdateTransform(Transform targetTransform)
        {
            if (!targetTransform.gameObject.activeSelf)
            {
                return;
            }

            float t = _timeService.DeltaTime * _attractionSpeed.Value;
            Vector3 cardPosition = targetTransform.position;

            if (_disableOnAttracted.Value &&
                Vector3.Distance(cardPosition, _transform.position) < 0.1f)
            {
                targetTransform.gameObject.SetActive(false);
                return;
            }

            targetTransform.position = Vector3.Lerp(
                cardPosition,
                _transform.position,
                t);
        }
    }
}