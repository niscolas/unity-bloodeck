using Zenject;

namespace Bloodeck
{
    public class CardDeckFromTemplateFactory :
        PlaceholderFactory<CardDeckTemplateSO, CardDeckMB>, ICardDeckFromTemplateFactory, ICardDeckMBFromTemplateFactory
    {
        private readonly CardDeckMBFactory _cardDeckFactory;

        public CardDeckFromTemplateFactory(CardDeckMBFactory cardDeckFactory)
        {
            _cardDeckFactory = cardDeckFactory;
        }

        public override CardDeckMB Create(CardDeckTemplateSO param)
        {
            return Internal_Create(param);
        }

        public ICardDeck Create(ICardDeckTemplate template)
        {
            if (!(template is CardDeckTemplateSO templateSO))
            {
                return default;
            }

            return Internal_Create(templateSO);
        }

        private CardDeckMB Internal_Create(CardDeckTemplateSO template)
        {
            CardDeckMB cardDeck = _cardDeckFactory.Create();
            cardDeck.LoadTemplate(template);

            return cardDeck;
        }
    }
}