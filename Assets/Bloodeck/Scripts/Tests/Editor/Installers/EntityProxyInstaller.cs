using Zenject;

namespace Bloodeck.Tests.Editor
{
    public class EntityProxyInstaller : Installer<EntityProxyInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IEntity>()
                .To<EntityProxy>()
                .AsTransient()
                .NonLazy();
        }
    }
}