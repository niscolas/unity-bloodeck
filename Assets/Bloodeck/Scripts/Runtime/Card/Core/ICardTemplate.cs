namespace Bloodeck
{
    public interface ICardTemplate
    {
        ICardComponents Components { get; }

        int Cost { get; }

        IEntity SelfEntity { get; }
    }
}