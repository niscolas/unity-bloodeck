using System;

namespace Bloodeck
{
    public interface IEntityAttackComponent : IEntityAttackComponentData
    {
        event Action<IEntity> AttackTriggered;
        event Action<float> AttackValueChanged;
        
        void Attack(IEntity target);
        void Attack(IEntityHealthComponent target);
        bool CheckCanAttack();
    }
}