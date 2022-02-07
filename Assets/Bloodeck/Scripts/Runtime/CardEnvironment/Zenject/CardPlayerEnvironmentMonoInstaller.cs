using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.InstallersAddComponentMenuPrefix + "Card Player Environment Installer")]
    public class CardPlayerEnvironmentMonoInstaller : MonoInstaller<CardPlayerEnvironmentMonoInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ICardSlots>()
                .FromMethod(
                    context =>
                        new CardSlotMBCollection(
                            ((CardPlayerEnvironmentMB) context.ObjectInstance)
                            .GetComponentsInChildren<CardSlotMB>()))
                .AsSingle()
                .WhenInjectedInto<CardPlayerEnvironmentMB>();
        }
    }
}