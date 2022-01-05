using Healthy;
using Zenject;

namespace Bloodeck
{
    public class HealthMonoBehaviourInstaller : Installer<HealthMonoBehaviourInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<HealthMonoBehaviour>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}