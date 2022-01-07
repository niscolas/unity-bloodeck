using Zenject;

namespace Bloodeck.Tests.Editor
{
    public class EntityHealthProxyInstaller : Installer<EntityHealthProxyInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IEntityHealth>()
                .To<EntityHealthProxy>()
                .AsTransient()
                .OnInstantiated(
                    (InjectContext context, IEntityHealth entityHealth) =>
                    {
                        entityHealth.Owner.Components.Add(entityHealth);
                    })
                .NonLazy();
        }
    }
}