using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Installer")]
    public class CardMonoInstaller : MonoInstaller<CardMonoInstaller>
    {
        public override void InstallBindings()
        {
            EntityMonoBehaviourInstaller.Install(Container);

            Container
                .Bind<CardMonoBehaviour>()
                .FromComponentInHierarchy(false)
                .AsSingle();

            Container
                .Bind<BaseCardComponentMonoBehaviour>()
                .FromComponentsInHierarchy(null, false)
                .AsSingle();

            Container
                .Bind<CardComponentsMonoBehaviour>()
                .FromComponentInHierarchy(false)
                .AsSingle();

            Container
                .Bind<CardAttackController>()
                .FromMethod(
                    context =>
                        new CardAttackController(context.ObjectInstance as ICardAttack))
                .AsSingle()
                .WhenInjectedInto(typeof(ICardAttack));

            Container
                .Bind<CardController>()
                .FromMethod(
                    context =>
                        new CardController(context.ObjectInstance as ICard))
                .AsSingle()
                .WhenInjectedInto(typeof(ICard));
        }
    }
}