using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.InstallersAddComponentMenuPrefix + "Card Deck from Template Factory Installer")]
    public class CardDeckFactoryMonoInstaller : MonoInstaller<CardDeckFactoryMonoInstaller>
    {
        [SerializeField]
        private CardDeckMB _cardDeckPrefab;

        public override void InstallBindings()
        {
            Container
                .Bind<CardDeckMB>()
                .FromInstance(_cardDeckPrefab)
                .AsSingle()
                .WhenInjectedInto(typeof(ICardDeckMBFactory));

            Container
                .BindFactory<Object, CardDeckMB, CardDeckMBFactory>()
                .FromFactory<PrefabFactory<CardDeckMB>>();

            Container
                .BindFactory<CardDeckTemplateSO, CardDeckMB, CardDeckFromTemplateFactory>();
        }
    }
}