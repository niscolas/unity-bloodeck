using niscolas.UnityUtils.Core.Extensions;

namespace Bloodeck
{
    public class CardDeckController : ICardDeck
    {
        public ICardFromTemplateFactory CardFromTemplateFactory => _humbleObject.CardFromTemplateFactory;

        public ICards Cards => _humbleObject.Cards;

        public ICardDeckTemplate Template
        {
            get => _humbleObject.Template;
            set => _humbleObject.Template = value;
        }

        public ICardDeckTemplate LoadedTemplate { get; private set; }

        private readonly ICardDeckData _humbleObject;

        public CardDeckController(ICardDeckData humbleObject)
        {
            _humbleObject = humbleObject;
        }

        public void LoadTemplate(ICardDeckTemplate template)
        {
            Cards.Clear();
            Template = template;
            LoadedTemplate = template;
            template.CardTemplates.ForEach(CreateCardFromTemplate);
        }

        private void CreateCardFromTemplate(ICardTemplate cardTemplate)
        {
            Cards.Add(CardFromTemplateFactory.Create(cardTemplate));
        }
    }
}