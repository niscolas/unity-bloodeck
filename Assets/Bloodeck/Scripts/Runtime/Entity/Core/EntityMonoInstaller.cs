using Zenject;

namespace Bloodeck
{
    public class EntityMonoInstaller : MonoInstaller<EntityMonoInstaller>
    {
        public override void InstallBindings()
        {
            HealthMonoBehaviourInstaller.Install(Container);
        }
    }
}