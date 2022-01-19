using UnityEngine;
using Zenject;

namespace Bloodeck
{
    public class CardMBFactory : PlaceholderFactory<Object, CardMB>, ICardFactory, ICardMBFactory
    {
        private readonly CardMB _prefab;

        public CardMBFactory(CardMB prefab)
        {
            _prefab = prefab;
        }

        public CardMB Create()
        {
            return Internal_Create();
        }

        ICard ICardFactory.Create()
        {
            return Internal_Create();
        }

        private CardMB Internal_Create()
        {
            return Create(_prefab);
        }
    }
}