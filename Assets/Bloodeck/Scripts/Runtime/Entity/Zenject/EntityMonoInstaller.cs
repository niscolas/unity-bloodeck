﻿using Healthy;
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

            Container.Bind<EntityAttackComponentController>()
                .FromMethod(
                    ctx =>
                        new EntityAttackComponentController(ctx.ObjectInstance as IEntityAttackComponentHumbleObject))
                .AsSingle()
                .WhenInjectedInto(typeof(IEntityAttackComponentHumbleObject));

            Container
                .Bind<EntityHealthComponentController>()
                .FromMethod(
                    ctx =>
                    {
                        EntityHealthComponentController controller =
                            new EntityHealthComponentController(ctx.ObjectInstance as IEntityHealthComponent);
                        Container.QueueForInject(controller);
                        return controller;
                    })
                .AsSingle()
                .WhenInjectedInto(typeof(IEntityHealthComponent));

            Container
                .Bind<EntityController>()
                .FromMethod(
                    ctx => new EntityController(ctx.ObjectInstance as IEntityHumbleObject))
                .AsSingle()
                .WhenInjectedInto(typeof(IEntityHumbleObject));
        }
    }
}