using Healthy;
using Zenject;

namespace Bloodeck.Tests.Editor
{
    public class EntityHealthControllerInstaller : Installer<EntityHealthControllerInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IHealth>()
                .FromMethod(
                    context => new HealthController(context.ObjectInstance as IHealth))
                .AsTransient();

            Container
                .Bind<IEntityHealthComponentData>()
                .FromSubstitute()
                .AsTransient()
                .WhenInjectedInto(typeof(EntityHealthComponentController));

            Container
                .Bind<IEntityHealthComponent>()
                .To<EntityHealthComponentController>()
                .AsTransient();
        }
    }
}