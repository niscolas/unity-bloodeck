using System;

namespace Bloodeck
{
    public interface ICardAttack : ICardAttackData
    {
        event Action<float> AttackValueChanged;

        void Attack(IEntity target);

        void Attack(IEntityHealth target);
    }
}