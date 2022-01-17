namespace Bloodeck
{
    public class CardSlotController : ICardSlot
    {
        public ICard Card { get; }

        public ICardSlotRestrictions CardRestrictions { get; }

        private readonly ICardSlotData _humbleObject;

        public CardSlotController(ICardSlotData humbleObject)
        {
            _humbleObject = humbleObject;
        }

        public bool TrySetCard(ICard card)
        {
            throw new System.NotImplementedException();
        }
    }
}