using UnityEngine;
using Zenject;

namespace Bloodeck
{
    public class CardDeckMBFactory : PlaceholderFactory<Object, CardDeckMB>, ICardDeckFactory, ICardDeckMBFactory
    {
        private readonly CardDeckMB _prefab;

        public CardDeckMBFactory(CardDeckMB prefab)
        {
            _prefab = prefab;
        }

        public CardDeckMB Create()
        {
            return Internal_Create();
        }

        ICardDeck ICardDeckFactory.Create()
        {
            return Internal_Create();
        }

        private CardDeckMB Internal_Create()
        {
            return Create(_prefab);
        }
    }
}