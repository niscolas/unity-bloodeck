namespace Bloodeck
{
    public interface IDeployableCardData
    {
        ICard SelfCard { get; }
        ICardSlot Slot { get; }
    }
}