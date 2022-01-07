using Zenject;

namespace Bloodeck
{
    public class EntityMonoBehaviourInstaller : Installer<EntityMonoBehaviourInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<EntityMonoBehaviour>()
                .FromComponentInHierarchy(false)
                .AsSingle();
        }
    }
}