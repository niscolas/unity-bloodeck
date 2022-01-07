using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Attack")]
    public class CardAttackMonoBehaviour : BaseCardComponentMonoBehaviour, ICardAttack
    {
        public int AttackValue
        {
            get => _owner.Template.AttackValue;
            set => _owner.Template.AttackValue = value;
        }

        [Inject]
        private CardAttackController _controller;

        public void Attack(IEntity target)
        {
            _controller.Attack(target);
        }

        public void Attack(IEntityHealth target)
        {
            _controller.Attack(target);
        }
    }
}