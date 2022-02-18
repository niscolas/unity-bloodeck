namespace Bloodeck
{
    public interface ICardData
    {
        int Cost { get; set; }
        ICardEffectMap Effects { get; }
        IDeployableCard Deployable { get; }
        ICardTemplate LoadedTemplate { get; }
        IOwnableCard Ownable { get; }
        IEntity SelfEntity { get; }
        ICardSlot Slot { get; }
    }
}