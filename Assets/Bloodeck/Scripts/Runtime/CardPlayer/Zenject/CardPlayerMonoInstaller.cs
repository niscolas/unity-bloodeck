using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.InstallersAddComponentMenuPrefix + "Card Player Installer")]
    public class CardPlayerMonoInstaller : MonoInstaller<CardPlayerMonoInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<CardPlayerController>()
                .FromMethod(
                    context => new CardPlayerController(context.ObjectInstance as CardPlayerMB))
                .AsSingle()
                .WhenInjectedInto(typeof(CardPlayerMB));
        }
    }
}