using UnityEngine;
using Zenject;

namespace Bloodeck
{
    public class DeckMBFactory : PlaceholderFactory<Object, DeckMB>, IDeckFactory, IDeckMBFactory
    {
        private readonly DeckMB _prefab;

        public DeckMBFactory(DeckMB prefab)
        {
            _prefab = prefab;
        }

        public DeckMB Create()
        {
            return Internal_Create();
        }

        IDeck IDeckFactory.Create()
        {
            return Internal_Create();
        }

        private DeckMB Internal_Create()
        {
            return Create(_prefab);
        }
    }
}