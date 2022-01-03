namespace Bloodeck
{
    public interface ICard
    {
        IEntity SelfEntity { get; }
        int Cost { get; }
    }
}