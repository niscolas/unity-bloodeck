namespace Bloodeck
{
    public interface ICardAttackTemplate : ICardComponentTemplate
    {
        float AttackValue { get; }
        
        IEntityFilters TargetFilters { get; }
    }
}