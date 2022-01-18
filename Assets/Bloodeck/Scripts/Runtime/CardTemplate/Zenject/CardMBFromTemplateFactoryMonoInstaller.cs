using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.InstallersAddComponentMenuPrefix + "Card MB from Template Factory Installer")]
    public class CardMBFromTemplateFactoryMonoInstaller : MonoInstaller<CardMBFromTemplateFactoryMonoInstaller>
    {
        [SerializeField]
        private GameObject _cardPrefab;

        public override void InstallBindings()
        {
            Container
                .Bind<GameObject>()
                .FromInstance(_cardPrefab)
                .AsSingle()
                .WhenInjectedInto(typeof(CardMBFromTemplateFactory));

            Container
                .BindFactory<GameObject, CardMB, CardMBFromTemplateFactory>()
                .FromFactory<PrefabFactory<CardMB>>();
        }
    }
}