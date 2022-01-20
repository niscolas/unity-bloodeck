using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.InstallersAddComponentMenuPrefix + "Deck from Template Factory Installer")]
    public class DeckFactoryMonoInstaller : MonoInstaller<DeckFactoryMonoInstaller>
    {
        [SerializeField]
        private DeckMB _deckPrefab;

        public override void InstallBindings()
        {
            Container
                .Bind<DeckMB>()
                .FromInstance(_deckPrefab)
                .AsSingle()
                .WhenInjectedInto(typeof(IDeckMBFactory));

            Container
                .BindFactory<Object, DeckMB, DeckMBFactory>()
                .FromFactory<PrefabFactory<DeckMB>>();

            Container
                .BindFactory<DeckTemplateSO, DeckMB, DeckMBFromTemplateFactory>();
        }
    }
}