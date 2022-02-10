using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.InstallersAddComponentMenuPrefix + "Card Game Environment Installer")]
    public class CardGameEnvironmentMonoInstaller : MonoInstaller<CardGameEnvironmentMonoInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ICardPlayerEnvironments>()
                .To<SerializableCardPlayerEnvironmentMBCollection>()
                .FromInstance(
                    new SerializableCardPlayerEnvironmentMBCollection(
                        FindObjectsOfType<CardPlayerEnvironmentMB>()))
                .AsSingle();
        }
    }
}