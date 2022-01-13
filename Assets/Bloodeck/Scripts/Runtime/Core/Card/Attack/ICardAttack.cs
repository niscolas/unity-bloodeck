using System;

namespace Bloodeck
{
    public interface ICardAttack : ICardAttackData
    {
        event Action<int> AttackValueChanged;

        void Attack(IEntity target);

        void Attack(IEntityHealth target);
    }
}