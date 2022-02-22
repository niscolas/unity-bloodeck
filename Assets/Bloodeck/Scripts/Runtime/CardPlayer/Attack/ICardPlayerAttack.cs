namespace Bloodeck
{
    public interface ICardPlayerAttack : ICardPlayerAttackData
    {
        bool CheckCanAttack();
        bool CheckCanAttackWithCard(ICard attackerCard, IEntity target);
        bool Attack(ICard attackerCard, IEntity target);
        void AttackRaw(ICard attackerCard, IEntity target);
    }
}