using niscolas.UnityUtils.Core;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Bloodeck.View.VisualScripting
{
    public class DeployableCardVSEventsMB : CachedMB
    {
        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private DeployableCardMB _deployableCard;

        public const string DeployedCustomEventName = nameof(DeployableCardMB.Deployed);

        private void OnEnable()
        {
            _deployableCard.Deployed += OnDeployed;
        }

        private void OnDisable()
        {
            _deployableCard.Deployed -= OnDeployed;
        }

        private void OnDeployed()
        {
            CustomEvent.Trigger(_gameObject, DeployedCustomEventName);
        }
    }
}