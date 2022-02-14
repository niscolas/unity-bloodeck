namespace Bloodeck
{
    public interface ICardEffectMap
    {
        bool TryGetValue(ICardEffectTrigger key, out ICardEffects value);
        void Trigger(ICardEffectTrigger trigger, IEntities rawTargets, ICard card);
    }
}