using niscolas.UnityUtils.Core.Extensions;

namespace Bloodeck
{
    public class CardSlotController : ICardSlot
    {
        public ICard Card
        {
            get => _humbleObject.Card;
            set => _humbleObject.Card = value;
        }

        public ICardSlotRestrictions Restrictions => _humbleObject.Restrictions;

        private readonly ICardSlotData _humbleObject;

        public CardSlotController(ICardSlotData humbleObject)
        {
            _humbleObject = humbleObject;
        }

        public bool CanPlaceCard(ICard card)
        {
            if (!CheckIsEmpty())
            {
                return false;
            }

            return Restrictions.Validate(card);
        }

        public bool CheckIsEmpty()
        {
            return Card.IsUnityNull();
        }

        public bool TrySetCard(ICard card)
        {
            if (!CanPlaceCard(card))
            {
                return false;
            }

            Card = card;

            return true;
        }

        public bool UnsetCard()
        {
            if (CheckIsEmpty())
            {
                return false;
            }

            ICard oldCard = Card;
            Card = default;
            oldCard.Deployable.TryUndeploy();

            return true;
        }
    }
}