using Healthy;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.InstallersAddComponentMenuPrefix + "Health Installer")]
    public class HealthMonoInstaller : MonoInstaller<HealthMonoInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<HealthMB>()
                .FromComponentInHierarchy(false)
                .AsSingle();
        }
    }
}