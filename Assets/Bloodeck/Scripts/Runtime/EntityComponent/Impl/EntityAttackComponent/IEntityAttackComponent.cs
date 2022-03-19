using System;

namespace Bloodeck
{
    public interface IEntityAttackComponent : IEntityAttackComponentData
    {
        event Action<IEntity> AttackTriggered;
        event Action<float> AttackValueChanged;

        bool Attack(IEntity target);
        bool Attack(IEntityHealthComponent target);
        bool CheckCanAttack();
    }
}