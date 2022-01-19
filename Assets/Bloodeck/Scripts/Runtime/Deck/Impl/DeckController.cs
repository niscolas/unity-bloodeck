using niscolas.UnityUtils.Core.Extensions;

namespace Bloodeck
{
    public class DeckController : IDeck
    {
        public ICardFromTemplateFactory CardFromTemplateFactory => _humbleObject.CardFromTemplateFactory;

        public ICards Cards => _humbleObject.Cards;

        public IDeckShuffler Shuffler => _humbleObject.Shuffler;

        public IDeckTemplate Template
        {
            get => _humbleObject.Template;
            set => _humbleObject.Template = value;
        }

        public IDeckTemplate LoadedTemplate { get; private set; }

        private readonly IDeckData _humbleObject;

        public DeckController(IDeckData humbleObject)
        {
            _humbleObject = humbleObject;
        }

        public void LoadTemplate(IDeckTemplate template)
        {
            Cards.Clear();
            Template = template;
            LoadedTemplate = template;
            template.CardTemplates.ForEach(CreateCardFromTemplate);
        }

        private void CreateCardFromTemplate(ICardTemplate cardTemplate)
        {
            Cards.Add(CardFromTemplateFactory.Create(cardTemplate));
            Shuffler.Shuffle(this);
        }
    }
}