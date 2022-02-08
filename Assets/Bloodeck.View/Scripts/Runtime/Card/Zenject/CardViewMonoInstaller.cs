using UnityEngine;
using Zenject;

namespace Bloodeck.View
{
    [AddComponentMenu(Constants.InstallersAddComponentMenuPrefix + "Card View Mono Installer")]
    public class CardViewMonoInstaller : MonoInstaller<CardViewMonoInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<CardViewerMB>().FromMethod(FindObjectOfType<CardViewerMB>).AsSingle();
        }
    }
}