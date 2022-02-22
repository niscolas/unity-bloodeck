using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    public class CardPlayerAttackMB : CachedMB, ICardPlayerAttack, IHumbleCardPlayerAttack
    {
        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private CardPlayerMB _selfCardPlayer;

        [Inject, SerializeField]
        private MatchMB _match;

        public ICardPlayer SelfCardPlayer => _selfCardPlayer;
        public IMatch Match => _match;

        [Inject]
        private CardPlayerAttackController _controller;

        public bool CheckCanAttack()
        {
            return _controller.CheckCanAttack();
        }

        public bool CheckCanAttackWithCard(ICard attackerCard, IEntity target)
        {
            return _controller.CheckCanAttackWithCard(attackerCard, target);
        }

        public bool Attack(ICard attackerCard, IEntity target)
        {
            return _controller.Attack(attackerCard, target);
        }

        public void AttackRaw(ICard attackerCard, IEntity target)
        {
            _controller.AttackRaw(attackerCard, target);
        }
    }
}