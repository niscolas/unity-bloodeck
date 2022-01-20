using UnityAtoms.Tags;
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
                .Bind<CardPlayerEnvironmentMB>()
                .FromMethod(FindTaggedEnvironment)
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

        private CardPlayerEnvironmentMB FindTaggedEnvironment(InjectContext context)
        {
            CardPlayerMB cardPlayer = (CardPlayerMB) context.ObjectInstance;

            if (!(cardPlayer.TryGetComponent(out CardPlayerEnvironmentLoaderByTagMB envLoader)))
            {
                return default;
            }

            GameObject possibleEnv = AtomTags.FindByTag(envLoader.TargetEnvironmentTag);

            if (!possibleEnv.TryGetComponent(out CardPlayerEnvironmentMB cardPlayerEnvironment))
            {
                return default;
            }

            return cardPlayerEnvironment;
        }
    }
}