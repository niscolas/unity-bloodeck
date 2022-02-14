using UnityEngine;
using Zenject;

namespace Bloodeck
{
    public class CardEntityLinkComponentMB : EntityComponentMB, ILinkEntityComponent<ICard>
    {
        [Inject, SerializeField]
        private CardMB _card;

        public ICard Link => _card;
    }
}