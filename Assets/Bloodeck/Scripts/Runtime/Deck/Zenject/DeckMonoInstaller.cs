using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.InstallersAddComponentMenuPrefix + "Deck Installer")]
    public class DeckMonoInstaller : MonoInstaller<DeckMonoInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IDeckShuffler>().To<DeckShuffler>().AsSingle();

            Container
                .Bind<DeckController>()
                .FromMethod(
                    context => new DeckController(context.ObjectInstance as IDeckHumbleObject))
                .AsSingle()
                .WhenInjectedInto(typeof(IDeckHumbleObject));
        }
    }
}