namespace Bloodeck
{
    public interface ICardTemplate
    {
        ICardComponentTemplates ComponentTemplates { get; }

        int Cost { get; }
        
        ICardEffectMap EffectMap { get; }

        IEntityTemplate SelfEntityTemplate { get; }
    }
}