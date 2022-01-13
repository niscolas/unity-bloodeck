using Healthy;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.InstallersAddComponentMenuPrefix + "Entity Installer")]
    public class EntityMBMonoInstaller : MonoInstaller<EntityMBMonoInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<EntityMB>()
                .FromComponentInHierarchy(false)
                .AsSingle();
           
            Container
                .Bind<BaseEntityComponentMB>()
                .FromComponentsInHierarchy(null, false)
                .AsSingle();

            Container
                .Bind<EntityComponentsMB>()
                .FromComponentInHierarchy(false)
                .AsSingle();

            Container
                .Bind<HealthMB>()
                .FromComponentInHierarchy(false)
                .AsSingle();

            Container
                .Bind<EntityHealthController>()
                .FromMethod(
                    context =>
                        new EntityHealthController(context.ObjectInstance as IEntityHealth))
                .AsSingle()
                .WhenInjectedInto(typeof(IEntityHealth));

            Container
                .Bind<EntityController>()
                .FromMethod(injectContext => new EntityController(injectContext.ObjectInstance as IEntity))
                .AsSingle()
                .WhenInjectedInto(typeof(IEntity));
        }
    }
}