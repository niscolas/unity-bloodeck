namespace Bloodeck
{
    public interface ICardTemplate
    {
        int Cost { get; }
        
        ICardEffectMap Effects { get; }

        IEntityTemplate SelfEntityTemplate { get; }
    }
}