using UnityEngine;
using Zenject;

namespace Bloodeck.View
{
    [AddComponentMenu(Constants.InstallersAddComponentMenuPrefix + "Input Installer")]
    public class InputMonoInstaller : MonoInstaller<InputMonoInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IMouseInputService>().To<MouseInputService>().AsSingle();
        }
    }
}