namespace Bloodeck
{
    public interface IEntityAttackComponentData : IEntityComponent,
        IEntityComponentWithTemplate<IEntityAttackComponentTemplate>
    {
        float AttackValue { get; set; }
        int AttacksPerTurn { get; }
        int AttacksLeftInTurn { get; }
    }
}