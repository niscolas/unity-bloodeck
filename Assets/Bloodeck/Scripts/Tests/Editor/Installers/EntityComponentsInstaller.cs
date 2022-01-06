using System;
using System.Collections.Generic;
using Zenject;

namespace Bloodeck.Tests.Editor
{
    public class EntityComponentsInstaller : Installer<EntityComponentsInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IDictionary<Type, IEntityComponent>>()
                .FromInstance(new Dictionary<Type, IEntityComponent>())
                .AsTransient()
                .WhenInjectedInto(typeof(IEntityComponents))
                .NonLazy();

            Container
                .Bind<IEntityComponents>()
                .To<EntityComponents>()
                .AsTransient()
                .WhenInjectedInto(typeof(IEntity))
                .NonLazy();
        }
    }
}