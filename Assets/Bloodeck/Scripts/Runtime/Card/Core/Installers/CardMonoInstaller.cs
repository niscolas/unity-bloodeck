using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Installer")]
    public class CardMonoInstaller : MonoInstaller<CardMonoInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<CardMB>()
                .FromComponentInHierarchy(false)
                .AsSingle();

            Container
                .Bind<BaseCardComponentMB>()
                .FromComponentsInHierarchy(null, false)
                .AsSingle();

            Container
                .Bind<CardComponentsMB>()
                .FromComponentInHierarchy(false)
                .AsSingle();

            Container
                .Bind<CardAttackController>()
                .FromMethod(
                    context =>
                        new CardAttackController(context.ObjectInstance as ICardAttack))
                .AsSingle()
                .WhenInjectedInto(typeof(ICardAttack));

            Container
                .Bind<CardController>()
                .FromMethod(
                    context =>
                        new CardController(context.ObjectInstance as ICard))
                .AsSingle()
                .WhenInjectedInto(typeof(ICard));
        }
    }
}