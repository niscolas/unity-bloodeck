using System;
using System.Collections;
using System.Collections.Generic;
using niscolas.UnityUtils.Core.Extensions;

namespace Bloodeck
{
    public class DeckController : IDeck
    {
        public event Action<ICard> CardCreated;
        public event Action<ICard> Added;
        public event Action Changed;

        public int Count => _humbleObject.Count;

        public ICardFromTemplateFactory CardFromTemplateFactory => _humbleObject.CardFromTemplateFactory;

        public IList<ICard> Cards => _humbleObject.Cards;

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
            Remove(topCard);

            return topCard;
        }

        public bool ReturnCard(ICard card)
        {
            if (Contains(card))
            {
                return false;
            }

            Add(card);

            return true;
        }

        public void Add(ICard card)
        {
            if (Contains(card))
            {
                return;
            }

            Cards.Add(card);
            OnAdded(card);
        }

        public bool Remove(ICard card)
        {
            if (!Contains(card))
            {
                return false;
            }

            Cards.Remove(card);
            OnChanged();

            return true;
        }

        public bool Contains(ICard card)
        {
            return Cards.Contains(card);
        }

        public IEnumerator<ICard> GetEnumerator()
        {
            return Cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void LoadTemplate(IDeckTemplate template)
        {
            Clear();
            CreateCards(template);
            Shuffle();
            SetTemplate(template);
        }

        private void Clear()
        {
            Cards.Clear();
        }

        private void OnAdded(ICard card)
        {
            NotifyAdded(card);
            OnChanged();
        }

        private void OnChanged()
        {
            NotifyChanged();
        }

        private void NotifyAdded(ICard card)
        {
            Added?.Invoke(card);
        }

        private void NotifyChanged()
        {
            Changed?.Invoke();
        }

        private ICard CreateCardFromTemplate(ICardTemplate cardTemplate)
        {
            ICard cardInstance = CardFromTemplateFactory.Create(cardTemplate);
            Add(cardInstance);

            return cardInstance;
        }

        private void CreateCards(IDeckTemplate template)
        {
            template.CardTemplates.ForEach(cardTemplate =>
            {
                ICard cardInstance = CreateCardFromTemplate(cardTemplate);
                CardCreated?.Invoke(cardInstance);
            });
        }

        private void SetTemplate(IDeckTemplate template)
        {
            _humbleObject.SetHumbleObjectLoadedTemplate(template);
        }

        private void Shuffle()
        {
            Shuffler.Shuffle(Cards);
        }
    }
}