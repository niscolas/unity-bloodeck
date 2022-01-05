namespace Bloodeck
{
    public interface ICard
    {
        ICardComponents Components { get; }

        int Cost { get; }

        IEntity SelfEntity { get; }
    }
}