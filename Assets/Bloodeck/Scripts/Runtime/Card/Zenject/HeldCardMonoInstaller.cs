using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.InstallersAddComponentMenuPrefix + "Held Card Installer")]
    public class HeldCardMonoInstaller : MonoInstaller<HeldCardMonoInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IHeldCard>()
                .To<HeldCard>()
                .AsSingle();
        }
    }
}