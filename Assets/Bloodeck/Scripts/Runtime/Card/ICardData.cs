namespace Bloodeck
{
    public interface ICardData
    {
        ICardComponents Components { get; }

        int Cost { get; set; }

        IEntity SelfEntity { get; }

        ICardTemplate Template { get; set; }
    }
}