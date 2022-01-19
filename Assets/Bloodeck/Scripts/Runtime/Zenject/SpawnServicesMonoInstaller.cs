using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.InstallersAddComponentMenuPrefix + "Spawn Services Installer")]
    public class SpawnServicesMonoInstaller : MonoInstaller<SpawnServicesMonoInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IDespawnService>()
                .To<UnityDestroyService>()
                .AsSingle();
        }
    }
}