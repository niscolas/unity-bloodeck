using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck.View.VisualScripting
{
    public class CardPlayerVSVariablesMB : CachedMB
    {
        [field: Header(HeaderTitles.Injections)]
        [field: Inject, SerializeField]
        public MatchMB Match { get; private set; }
    }
}