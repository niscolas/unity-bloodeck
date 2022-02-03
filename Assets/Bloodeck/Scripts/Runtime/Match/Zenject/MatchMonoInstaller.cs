using UnityEngine;
using Zenject;

namespace Bloodeck.Zenject
{
    [AddComponentMenu(Constants.InstallersAddComponentMenuPrefix + "Match Installer")]
    public class MatchMonoInstaller : MonoInstaller<MatchMonoInstaller>
    {
        [SerializeField]
        private MatchMB _match;

        public override void InstallBindings()
        {
            Container
                .Bind<MatchMB>()
                .FromInstance(_match)
                .AsSingle();
        }
    }
}