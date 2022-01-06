using Zenject;

namespace Bloodeck.Tests.Editor
{
    public class FullCardAttackProxyInstaller : Installer<FullCardAttackProxyInstaller>
    {
        public override void InstallBindings()
        {
            CardComponentsInstaller.Install(Container);
            CardProxyToICardAttackInstaller.Install(Container);
            CardAttackProxyInstaller.Install(Container);
        }
    }
}