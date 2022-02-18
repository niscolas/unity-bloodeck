using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Bloodeck
{
    public class MatchMonoInstaller : MonoInstaller<MatchMonoInstaller>
    {
        public override void InstallBindings()
        {
            // Container.Bind<CardPlayerMB>().FromComponentsInHierarchy().AsSingle();
            Container
                .Bind<List<CardPlayerMB>>().FromMethod(_ =>
                {
                    List<CardPlayerMB> players = FindObjectsOfType<CardPlayerMB>().ToList();
                    return players;
                }).AsSingle();
            Container
                .Bind<MatchController>()
                .FromMethod(
                    ctx => new MatchController((IMatchHumbleObject) ctx.ObjectInstance))
                .AsSingle()
                .WhenInjectedInto(typeof(IMatchHumbleObject));
        }
    }
}