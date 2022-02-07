using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.InstallersAddComponentMenuPrefix + "Entity Installer")]
    public class EntityMonoInstaller : MonoInstaller<EntityMonoInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<EntityComponentMB>()
                .FromComponentsInHierarchy(null, false)
                .AsSingle();

            Container
                .Bind<EntityHealthController>()
                .FromMethod(
                    ctx => new EntityHealthController(ctx.ObjectInstance as IEntityHealth))
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