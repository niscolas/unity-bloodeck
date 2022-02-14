using Zenject;

namespace Bloodeck.Tests.Editor
{
    public class CardAttackControllerInstaller : Installer<CardAttackControllerInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IEntityAttackComponentData>()
                .FromSubstitute()
                .AsTransient()
                .WhenInjectedInto(typeof(EntityAttackComponentController));

            Container
                .Bind<IEntityAttackComponent>()
                .To<EntityAttackComponentController>()
                .AsTransient();
        }
    }
}