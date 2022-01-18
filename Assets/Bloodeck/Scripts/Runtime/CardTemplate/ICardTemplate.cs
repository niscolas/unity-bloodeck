namespace Bloodeck
{
    public interface ICardTemplate
    {
        ICardComponentTemplates ComponentTemplates { get; }

        int Cost { get; }

        IEntityTemplate SelfEntityTemplate { get; }
    }
}