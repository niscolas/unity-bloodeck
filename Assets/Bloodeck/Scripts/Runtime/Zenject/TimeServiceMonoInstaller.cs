using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.InstallersAddComponentMenuPrefix + "Time Service Installer")]
    public class TimeServiceMonoInstaller : MonoInstaller<TimeServiceMonoInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IUnityTimeService>().To<UnityTimeService>().AsSingle();
        }
    }
}