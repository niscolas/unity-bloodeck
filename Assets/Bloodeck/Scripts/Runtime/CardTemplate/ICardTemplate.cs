namespace Bloodeck
{
    public interface ICardTemplate
    {
        ICardComponentTemplates ComponentTemplates { get; }

        int Cost { get; }
        
        ICardEffectMap Effects { get; }

        IEntityTemplate SelfEntityTemplate { get; }
    }
}