using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.InstallersAddComponentMenuPrefix + "Card Player Installer")]
    public class CardPlayerMonoInstaller : MonoInstaller<CardPlayerMonoInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<CardPlayerEnvironmentMB>().FromComponentInHierarchy().AsSingle();

            Container.Bind<DeckMB>().FromComponentInHierarchy().AsSingle();

            Container.Bind<CardHandMB>().FromComponentInHierarchy().AsSingle();

            Container
                .Bind<CardPlayerController>()
                .FromMethod(
                    context => new CardPlayerController(context.ObjectInstance as CardPlayerMB))
                .AsSingle()
                .WhenInjectedInto(typeof(CardPlayerMB));

            Container.Bind<CardPlayerMB>().FromComponentInHierarchy().AsSingle();
        }
    }
}