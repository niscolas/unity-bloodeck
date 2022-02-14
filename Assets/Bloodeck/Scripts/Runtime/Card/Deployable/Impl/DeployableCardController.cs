using System;
using niscolas.UnityUtils.Core.Extensions;

namespace Bloodeck
{
    public class DeployableCardController : IDeployableCard
    {
        public event Action Deployed;
        public event Action Undeployed;

        public ICard SelfCard => _humbleObject.SelfCard;

        public ICardSlot Slot => _humbleObject.Slot;

        private readonly IDeployableCardHumbleObject _humbleObject;

        public DeployableCardController(IDeployableCardHumbleObject humbleObject)
        {
            _humbleObject = humbleObject;
        }

        public bool CheckIsDeployed()
        {
            return !Slot.IsUnityNull();
        }

        public bool TryDeploy(ICardSlot slot)
        {
            if (!slot.TrySetCard(SelfCard))
            {
                return false;
            }

            _humbleObject.SetSlot(slot);
            NotifyDeployed();

            return true;
        }

        public bool TryUndeploy()
        {
            if (!CheckCanUndeploy())
            {
                return false;
            }

            Slot.UnsetCard();
            NotifyUndeployed();

            return true;
        }

        private bool CheckCanUndeploy()
        {
            return !Slot.IsUnityNull() &&
                   Slot.Card == SelfCard;
        }

        private void NotifyDeployed()
        {
            Deployed?.Invoke();
        }

        private void NotifyUndeployed()
        {
            Undeployed?.Invoke();
        }
    }
}