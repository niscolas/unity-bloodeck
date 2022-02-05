using niscolas.UnityUtils.Core.Extensions;

namespace Bloodeck
{
    public class DeckController : IDeck
    {
        public ICardFromTemplateFactory CardFromTemplateFactory => _humbleObject.CardFromTemplateFactory;

        public ICards Cards => _humbleObject.Cards;

        public IDeckShuffler Shuffler => _humbleObject.Shuffler;

        public IDeckTemplate LoadedTemplate => _humbleObject.LoadedTemplate;

        private readonly IDeckHumbleObject _humbleObject;

        public DeckController(IDeckHumbleObject humbleObject)
        {
            _humbleObject = humbleObject;
        }

        public ICard DrawFromTop()
        {
            if (Cards.IsNullOrEmpty())
            {
                return default;
            }

            ICard topCard = Cards[0];
            Cards.Remove(topCard);

            return topCard;
        }

        public void LoadTemplate(IDeckTemplate template)
        {
            Cards.Clear();
            template.CardTemplates.ForEach(CreateCardFromTemplate);
            SetTemplate(template);
        }

        private void CreateCardFromTemplate(ICardTemplate cardTemplate)
        {
            Cards.Add(CardFromTemplateFactory.Create(cardTemplate));
            Shuffler.Shuffle(this);
        }

        private void SetTemplate(IDeckTemplate template)
        {
            _humbleObject.SetHumbleObjectLoadedTemplate(template);
        }
    }
}