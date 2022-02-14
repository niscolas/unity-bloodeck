using System;

namespace Bloodeck
{
    public interface IDeployableCard : IDeployableCardData
    {
        event Action Deployed;
        event Action Undeployed;

        bool CheckIsDeployed();
        bool TryDeploy(ICardSlot slot);
        bool TryUndeploy();
    }
}