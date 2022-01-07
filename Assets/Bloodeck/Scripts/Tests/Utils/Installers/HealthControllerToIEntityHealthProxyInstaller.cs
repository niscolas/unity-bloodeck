using Healthy;
using Zenject;

namespace Bloodeck.Tests.Editor
{
    public class
        HealthControllerToIEntityHealthProxyInstaller : Installer<HealthControllerToIEntityHealthProxyInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IHealth>()
                .FromMethod(context => new HealthController(context.ObjectInstance as IHealth))
                .AsTransient()
                .WhenInjectedInto(typeof(IEntityHealth))
                .NonLazy();
        }
    }
}