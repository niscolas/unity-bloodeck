using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Installer")]
    public class CardMonoInstaller : MonoInstaller<CardMonoInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<CardComponentMB>().FromComponentsInHierarchy(null, false).AsSingle();
            
            Container.Bind<CardGameEnvironmentMB>().FromInstance(FindObjectOfType<CardGameEnvironmentMB>());

            Container.Bind<CardAttackController>()
                .FromMethod(
                    context =>
                        new CardAttackController(context.ObjectInstance as ICardAttack))
                .AsSingle()
                .WhenInjectedInto(typeof(ICardAttack));

            Container
                .Bind<CardController>()
                .FromMethod(
                    context =>
                        new CardController(context.ObjectInstance as CardMB))
                .AsSingle()
                .WhenInjectedInto(typeof(CardMB));
        }
    }
}