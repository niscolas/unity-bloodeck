using UnityAtoms.BaseAtoms;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.InstallersAddComponentMenuPrefix + "Card Player Installer")]
    public class CardPlayerMonoInstaller : MonoInstaller<CardPlayerMonoInstaller>
    {
        [SerializeField]
        private StringReference _environmentId;

        public override void InstallBindings()
        {
            CardPlayerEnvironmentMB environment = CardPlayerEnvironmentIdMB.WithId(_environmentId.Value).Item;

            Container
                .Bind<CardPlayerEnvironmentMB>()
                .FromInstance(environment)
                .AsSingle()
                .WhenInjectedInto(typeof(CardPlayerMB));

            Container
                .Bind<CardPlayerController>()
                .FromMethod(
                    context => new CardPlayerController(context.ObjectInstance as CardPlayerMB))
                .AsSingle()
                .WhenInjectedInto(typeof(CardPlayerMB));

            Container
                .Bind<IDeckMBFromTemplateFactory>()
                .To<DeckMBFromTemplateFactory>()
                .AsSingle();

            Container
                .Bind<CardPlayerMB>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}