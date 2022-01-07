namespace Bloodeck
{
    public interface ICard
    {
        ICardComponents Components { get; }

        int Cost { get; set; }

        IEntity SelfEntity { get; }
    }
}