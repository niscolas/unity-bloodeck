using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Bloodeck
{
    public class CardHandMB : CachedMB, ICardHand
    {
        [SerializeField]
        private SerializableCardMBCollection _content;

        [SerializeField]
        private IntReference _maxCardCount = new IntReference();

        [Header(HeaderTitles.Output)]
        [SerializeField]
        private IntReference _cardCountOutput = new IntReference();

        [Header(HeaderTitles.Injections)]
        [SerializeField]
        private CardPlayerMB _cardPlayer;

        public event Action<ICard> Added;
        public event Action<ICard> Removed;
        public event Action Cleared;

        public int Count => _content.Count;
        public bool IsReadOnly => false;

        public int Capacity
        {
            get => _maxCardCount.Value;
            set => _maxCardCount.Value = value;
        }

        public ICard this[int index]
        {
            get => _content[index];
            set => _content[index] = value as CardMB;
        }

        public ICollection<CardMB> AsMBs => _content.AsMBs;

        private void Start()
        {
            AddExistingCards();

            _content.Added += OnAdded;
            _content.Removed += OnRemoved;
            _content.Changed += OnChanged;
            _content.Cleared += OnCleared;
        }

        private void OnDestroy()
        {
            _content.Added -= OnAdded;
            _content.Removed -= OnRemoved;
            _content.Changed -= OnChanged;
            _content.Cleared -= OnCleared;
        }

        public bool CheckIsFull()
        {
            return Count == Capacity;
        }

        public IEnumerator<ICard> GetEnumerator()
        {
            return _content.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(ICard item)
        {
            if (CheckIsFull())
            {
                return;
            }

            _content.AddParentItem(item);
        }

        public int IndexOf(ICard item)
        {
            return _content.IndexOfParentItem(item);
        }

        public void Insert(int index, ICard item)
        {
            _content.InsertParentItem(index, item);
        }

        public void RemoveAt(int index)
        {
            ICard item = _content[index];
            _content.Remove(item);
        }

        public void Clear()
        {
            _content.Clear();
        }

        public bool Contains(ICard item)
        {
            return _content.ContainsParentItem(item);
        }

        public void CopyTo(ICard[] array, int arrayIndex)
        {
            _content.CopyToParentArray(array, arrayIndex);
        }

        public bool Remove(ICard item)
        {
            bool result = _content.RemoveParentItem(item);
            return result;
        }

        private void AddExistingCards()
        {
            foreach (ICard card in _content)
            {
                OnAdded(card);
            }
        }

        private void UpdateCardCountOutput()
        {
            _cardCountOutput.Value = Count;
        }

        private void OnAdded(ICard item)
        {
            LinkToCard(item);
            Added?.Invoke(item);
        }

        private void OnRemoved(ICard item)
        {
            UnlinkFromCard(item);
            Removed?.Invoke(item);
        }

        private void OnChanged()
        {
            UpdateCardCountOutput();
        }

        private void OnCleared()
        {
            UnlinkAllCards();
            Cleared?.Invoke();
        }

        private void LinkToCard(ICard card)
        {
            ExtractCardFromHandComponent(card).LinkHand(this);
        }

        private void UnlinkAllCards()
        {
            this.ForEach(UnlinkFromCard);
        }

        private void UnlinkFromCard(ICard card)
        {
            ExtractCardFromHandComponent(card).UnlinkHand();
        }

        private static CardInHandMB ExtractCardFromHandComponent(ICard card)
        {
            return ((CardMB) card).GetComponentInChildren<CardInHandMB>();
        }
    }
}