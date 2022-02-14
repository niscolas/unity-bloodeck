namespace Bloodeck
{
    public interface ICardEffectSystem
    {
        void Apply(IEntities targets, ICard instigator = null);
        void Apply(IEntity target, ICard instigator = null);
    }
}