using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Deck User")]
    public class DeckUserMB : CachedMB
    {
        [Inject, SerializeField]
        private CardPlayerMB _cardPlayer;

        [SerializeField]
        private DeckTemplateSO _template;

        private void Start()
        {
            _cardPlayer.UseDeckTemplate(_template);
        }
    }
}