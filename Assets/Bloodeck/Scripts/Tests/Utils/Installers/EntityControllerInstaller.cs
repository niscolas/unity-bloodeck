using Zenject;

namespace Bloodeck.Tests.Editor
{
    public class EntityControllerInstaller : Installer<EntityControllerInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IEntityData>()
                .FromSubstitute()
                .AsTransient();

            Container
                .Bind<IEntity>()
                .To<EntityController>()
                .AsTransient();
        }
    }
}