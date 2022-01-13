using Zenject;

namespace Bloodeck.Tests.Editor
{
    public class FullCardAttackInstaller : Installer<FullCardAttackInstaller>
    {
        public override void InstallBindings()
        {
            CardComponentsInstaller.Install(Container);
            CardProxyToICardAttackInstaller.Install(Container);
            CardAttackInstaller.Install(Container);
        }
    }
}