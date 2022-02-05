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

        [SerializeField]
        private StringReference _deckId;

        [SerializeField]
        private StringReference _cardHandId;

        public override void InstallBindings()
        {
            CardPlayerEnvironmentMB environment = CardPlayerEnvironmentIdMB.WithId(_environmentId.Value).Item;
            DeckMB deck = DeckIdMB.WithId(_deckId.Value).Item;
            CardHandMB cardHand = CardHandIdMB.WithId(_cardHandId.Value).Item;

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

            Container.Bind<DeckMB>().FromInstance(deck).AsSingle();
            Container.Bind<CardHandMB>().FromInstance(cardHand).AsSingle();
            Container.Bind<CardPlayerMB>().FromComponentInHierarchy().AsSingle();
        }
    }
}