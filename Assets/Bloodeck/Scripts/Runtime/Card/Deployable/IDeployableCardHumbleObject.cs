namespace Bloodeck
{
    public interface IDeployableCardHumbleObject : IDeployableCardData
    {
        void SetSlot(ICardSlot slot);
    }
}