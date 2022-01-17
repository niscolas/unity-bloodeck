using niscolas.UnityUtils.Core.Extensions;
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
                .When(context =>
                {
                    if (context.ObjectInstance is CardPlayerEnvironmentMB cardPlayerEnvironment)
                    {
                        return cardPlayerEnvironment.Slots.IsNullOrEmpty();
                    }
                    else
                    {
                        return false;
                    }
                });
        }
    }
}