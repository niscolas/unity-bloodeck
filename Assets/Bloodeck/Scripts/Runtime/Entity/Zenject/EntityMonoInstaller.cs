using Healthy;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.InstallersAddComponentMenuPrefix + "Entity Installer")]
    public class EntityMonoInstaller : MonoInstaller<EntityMonoInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<EntityComponentMB>().FromComponentsInHierarchy().AsSingle();

            Container
                .Bind<IHealth>()
                .To<HealthController>()
                .FromMethod(
                    ctx => new HealthController(ctx.ObjectInstance as IHealthData))
                .AsSingle();

            Container
                .Bind<EntityHealthController>()
                .FromMethod(
                    ctx =>
                    {
                       EntityHealthController controller = new EntityHealthController(ctx.ObjectInstance as IEntityHealth);
                       Container.QueueForInject(controller);
                       return controller;
                    })
                .AsSingle()
                .WhenInjectedInto(typeof(IEntityHealth));

            Container
                .Bind<EntityController>()
                .FromMethod(
                    ctx => new EntityController(ctx.ObjectInstance as IEntityHumbleObject))
                .AsSingle()
                .WhenInjectedInto(typeof(IEntityHumbleObject));
        }
    }
}