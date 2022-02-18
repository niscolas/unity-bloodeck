namespace Bloodeck
{
    public interface IEntityAttackComponentTemplate : IEntityComponentTemplate
    {
        float AttackValue { get; }
        int AttacksPerTurn { get; }
        IEntityFilters TargetFilters { get; }
    }
}