using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck.View
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Viewable Card")]
    public class ViewableCardMB : CachedMB
    {
        [Inject, SerializeField]
        private CardViewerMB _cardViewer;

        [Inject, SerializeField]
        private CardMB _card;

        [Button]
        public void View()
        {
            _cardViewer.View(_card);
        }
    }
}