using Zenject;

namespace Bloodeck
{
    public class DeckFromTemplateFactory :
        PlaceholderFactory<DeckTemplateSO, DeckMB>, IDeckFromTemplateFactory, IDeckMBFromTemplateFactory
    {
        private readonly DeckMBFactory _deckFactory;

        public DeckFromTemplateFactory(DeckMBFactory deckFactory)
        {
            _deckFactory = deckFactory;
        }

        public override DeckMB Create(DeckTemplateSO param)
        {
            return Internal_Create(param);
        }

        public IDeck Create(IDeckTemplate template)
        {
            if (!(template is DeckTemplateSO templateSO))
            {
                return default;
            }

            return Internal_Create(templateSO);
        }

        private DeckMB Internal_Create(DeckTemplateSO template)
        {
            DeckMB deck = _deckFactory.Create();
            deck.LoadTemplate(template);

            return deck;
        }
    }
}