using Zenject;

namespace Bloodeck
{
    public class CardMBFromTemplateFactory : PlaceholderFactory<CardTemplateSO, CardMB>, ICardFromTemplateFactory
    {
        private readonly CardMBFactory _cardFactory;

        public CardMBFromTemplateFactory(CardMBFactory cardFactory)
        {
            _cardFactory = cardFactory;
        }

        public override CardMB Create(CardTemplateSO param)
        {
            return Internal_Create(param) as CardMB;
        }

        public ICard Create(ICardTemplate template)
        {
            if (!(template is CardTemplateSO templateSO))
            {
                return default;
            }

            return Internal_Create(templateSO);
        }

        private CardMB Internal_Create(CardTemplateSO template)
        {
            CardMB card = _cardFactory.Create();
            card.LoadTemplate(template);

            return card;
        }
    }
}