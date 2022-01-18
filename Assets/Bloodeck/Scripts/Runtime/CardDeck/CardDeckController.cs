namespace Bloodeck
{
    public class CardDeckController : ICardDeck
    {
        public ICardFromTemplateFactory CardFromTemplateFactory => _humbleObject.CardFromTemplateFactory;

        public ICardsFactory CardsFactory => _humbleObject.CardsFactory;

        public ICardTemplates CardTemplates => _humbleObject.CardTemplates;

        private readonly ICardDeckData _humbleObject;

        public CardDeckController(ICardDeckData humbleObject)
        {
            _humbleObject = humbleObject;
        }

        public ICards Instantiate()
        {
            ICards cards = CardsFactory.Create();

            foreach (ICardTemplate cardTemplate in CardTemplates)
            {
                cards.Add(
                    CardFromTemplateFactory.Create(cardTemplate));
            }

            return cards;
        }
    }
}