using UnityEngine;
using Zenject;

namespace Bloodeck.View
{
    [AddComponentMenu(Constants.InstallersAddComponentMenuPrefix + "Input Installer")]
    public class InputMonoInstaller : MonoInstaller<InputMonoInstaller>
    {
        [SerializeField]
        private PointerInputServiceMB _pointerInputService;

        public override void InstallBindings()
        {
            Container
                .Bind<IPointerInputService>()
                .FromInstance(_pointerInputService)
                .AsSingle();
        }
    }
}