using System;
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
            LoadTemplate(template, null);
        }

        public void LoadTemplate(IDeckTemplate template, Action<ICard> cardCreatedCallback)
        {
            Clear();
            CreateCards(template, cardCreatedCallback);
            Shuffle();
            SetTemplate(template);
        }

        private void Clear()
        {
            Cards.Clear();
        }

        private ICard CreateCardFromTemplate(ICardTemplate cardTemplate)
        {
            ICard cardInstance = CardFromTemplateFactory.Create(cardTemplate);
            Cards.Add(cardInstance);

            return cardInstance;
        }

        private void CreateCards(IDeckTemplate template, Action<ICard> cardCreatedCallback)
        {
            template.CardTemplates.ForEach(cardTemplate =>
            {
                ICard cardInstance = CreateCardFromTemplate(cardTemplate);
                cardCreatedCallback?.Invoke(cardInstance);
            });
        }

        private void SetTemplate(IDeckTemplate template)
        {
            _humbleObject.SetHumbleObjectLoadedTemplate(template);
        }

        private void Shuffle()
        {
            Shuffler.Shuffle(this);
        }
    }
}