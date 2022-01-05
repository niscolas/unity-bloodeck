﻿using Zenject;

namespace Bloodeck
{
    public class CardInstaller : Installer<CardInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<EntityMonoBehaviour>()
                .FromComponentInHierarchy(false)
                .AsSingle();

            Container
                .Bind<CardController>()
                .FromMethod(injectContext => new CardController(injectContext.ObjectInstance as ICard))
                .AsSingle()
                .WhenInjectedInto(typeof(ICard));
        }
    }
}