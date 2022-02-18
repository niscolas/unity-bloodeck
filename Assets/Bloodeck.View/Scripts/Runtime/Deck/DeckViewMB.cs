using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck.View
{
    public class DeckViewMB : CachedMB
    {
        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private DeckMB _deck;
        
    }
}