namespace Bloodeck
{
    public interface ICardAttack : ICardComponent
    {
        int AttackValue { get; set; }

        void Attack(IEntity target);

        void Attack(IEntityHealth target);
    }
}