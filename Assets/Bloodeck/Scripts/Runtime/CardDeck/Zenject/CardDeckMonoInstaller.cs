using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.InstallersAddComponentMenuPrefix + "Card Deck Installer")]
    public class CardDeckMonoInstaller : MonoInstaller<CardDeckMonoInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<CardDeckController>()
                .FromMethod(
                    context => new CardDeckController(context.ObjectInstance as ICardDeckData))
                .AsSingle()
                .WhenInjectedInto(typeof(ICardDeck));
        }
    }
}