using UnityEngine;
using Zenject;

namespace Bloodeck.View
{
    public class CameraMonoInstaller  : MonoInstaller<CameraMonoInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<Camera>().FromMethod(() => Camera.main).AsSingle();
        }
    }
}