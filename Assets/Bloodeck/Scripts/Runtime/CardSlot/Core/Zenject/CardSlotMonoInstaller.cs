using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.InstallersAddComponentMenuPrefix + "Card Slot Installer")]
    public class CardSlotMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<CardSlotController>()
                .FromMethod(context => new CardSlotController(context.ObjectInstance as ICardSlotData))
                .AsSingle()
                .WhenInjectedInto(typeof(CardSlotMB));
        }
    }
}