using Zenject;

namespace Bloodeck
{
    public class EntityMonoBehaviourInstaller : Installer<EntityMonoBehaviourInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<EntityMB>()
                .FromComponentInHierarchy(false)
                .AsSingle();
        }
    }
}