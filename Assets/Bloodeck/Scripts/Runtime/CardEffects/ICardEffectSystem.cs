namespace Bloodeck
{
    public interface ICardEffectSystem
    {
        void Apply(IEntities targets, ICard instigator);
    }
}