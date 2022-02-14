using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.InstallersAddComponentMenuPrefix + "Card from Template Factory Installer")]
    public class CardFactoryMonoInstaller : MonoInstaller<CardFactoryMonoInstaller>
    {
        [SerializeField]
        private CardMB _cardPrefab;

        public override void InstallBindings()
        {
            Container
                .Bind<CardMB>()
                .FromInstance(_cardPrefab)
                .AsSingle()
                .WhenInjectedInto(typeof(ICardMBFactory));

            Container
                .BindFactory<Object, CardMB, CardMBFactory>()
                .FromFactory<PrefabFactory<CardMB>>();

            Container
                .BindFactory<CardTemplateSO, CardMB, CardMBFromTemplateFactory>();
        }
    }
}