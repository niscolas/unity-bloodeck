using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Game Environment")]
    public class CardGameEnvironmentMB : CachedMB, ICardGameEnvironment
    {
        [Inject, SerializeReference]
        private ICardPlayerEnvironments _cardPlayerEnvironments;

        public ICardPlayerEnvironments CardPlayerEnvironments => _cardPlayerEnvironments;
    }
}