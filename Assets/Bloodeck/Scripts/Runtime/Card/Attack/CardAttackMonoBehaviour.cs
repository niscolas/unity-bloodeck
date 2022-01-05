using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Attack")]
    public class CardAttackMonoBehaviour : CachedMonoBehaviour, ICardAttack
    {
        [Inject, SerializeField]
        private CardMonoBehaviour _card;

        public ICard SelfCard => _card;

        public int AttackValue
        {
            get => _card.Template.AttackValue;
            set => _card.Template.AttackValue = value;
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