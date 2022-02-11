namespace Bloodeck
{
    public interface ICardData
    {
        ICardComponents Components { get; }

        int Cost { get; set; }

        IEntity SelfEntity { get; }

        ICardEffectMap Effects { get; }

        ICardPlayer Owner { get; set; }

        ICardTemplate LoadedTemplate { get; }
    }
}