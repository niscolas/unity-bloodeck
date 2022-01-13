using Zenject;

namespace Bloodeck.Tests.Editor
{
    public class CardProxyToICardAttackInstaller : Installer<CardProxyToICardAttackInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ICard>()
                .To<CardProxy>()
                .AsTransient()
                .WhenInjectedInto(typeof(ICardAttackData))
                .NonLazy();
        }
    }
}