using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Installer")]
    public class CardMonoInstaller : MonoInstaller<CardMonoInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<MatchMB>().FromMethod(_ => FindObjectOfType<MatchMB>()).AsSingle();
            Container.Bind<CardGameEnvironmentMB>().FromInstance(FindObjectOfType<CardGameEnvironmentMB>());

            Container
                .Bind<DeployableCardController>()
                .FromMethod(
                    ctx => new DeployableCardController(ctx.ObjectInstance as IDeployableCardHumbleObject))
                .AsSingle()
                .WhenInjectedInto<IDeployableCardHumbleObject>();

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