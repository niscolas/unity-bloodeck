using System;
using System.Collections.Generic;
using Zenject;

namespace Bloodeck.Tests.Editor
{
    public class CardComponentsInstaller : Installer<CardComponentsInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IDictionary<Type, ICardComponent>>()
                .FromInstance(new Dictionary<Type, ICardComponent>())
                .AsTransient()
                .WhenInjectedInto(typeof(ICardComponents))
                .NonLazy();

            Container
                .Bind<ICardComponents>()
                .To<CardComponents>()
                .AsTransient()
                .WhenInjectedInto(typeof(ICard))
                .NonLazy();
        }
    }
}