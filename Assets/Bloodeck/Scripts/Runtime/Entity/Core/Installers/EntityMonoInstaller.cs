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
            Container
                .Bind<BaseEntityComponentMonoBehaviour>()
                .FromComponentsInHierarchy(null, false)
                .AsSingle();

            Container
                .Bind<EntityComponentsMonoBehaviour>()
                .FromComponentInHierarchy(false)
                .AsSingle();

            Container
                .Bind<HealthMonoBehaviour>()
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