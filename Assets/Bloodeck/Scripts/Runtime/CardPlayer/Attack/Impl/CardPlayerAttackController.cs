namespace Bloodeck
{
    public class CardPlayerAttackController : ICardPlayerAttack
    {
        public ICardPlayer SelfCardPlayer => _humbleObject.SelfCardPlayer;
        public IMatch Match => _humbleObject.Match;

        private readonly IHumbleCardPlayerAttack _humbleObject;

        public CardPlayerAttackController(IHumbleCardPlayerAttack humbleObject)
        {
            _humbleObject = humbleObject;
        }

        public bool CheckCanAttack()
        {
            return true;
        }

        public bool CheckCanAttackWithCard(ICard attackerCard, IEntity target)
        {
            return SelfCardPlayer.CheckOwnsCard(attackerCard) &&
                   MatchUtility.CheckAreOppositeTeams(
                       SelfCardPlayer.SelfEntity.Team,
                       target.Team);
        }

        public bool Attack(ICard attackerCard, IEntity target)
        {
            if (!CheckCanAttackWithCard(attackerCard, target))
            {
                return false;
            }

            AttackRaw(attackerCard, target);

            return true;
        }

        public void AttackRaw(ICard attackerCard, IEntity target)
        {
            if (!attackerCard.SelfEntity.Components.TryGet(out IEntityAttackComponent entityAttackComponent))
            {
                return;
            }

            entityAttackComponent.Attack(target);
        }
    }
}