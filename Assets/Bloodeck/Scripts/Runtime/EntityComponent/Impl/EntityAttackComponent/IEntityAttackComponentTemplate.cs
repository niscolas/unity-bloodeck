namespace Bloodeck
{
    public interface IEntityAttackComponentTemplate : IEntityComponentTemplate
    {
        float AttackValue { get; }

        IEntityFilters TargetFilters { get; }
    }
}