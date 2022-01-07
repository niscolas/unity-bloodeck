using Zenject;

namespace Bloodeck.Tests.Editor
{
    public class FullEntityHealthProxyInstaller : Installer<FullEntityHealthProxyInstaller>
    {
        public override void InstallBindings()
        {
            HealthControllerToIEntityHealthProxyInstaller.Install(Container);
            EntityComponentsInstaller.Install(Container);
            EntityHealthProxyInstaller.Install(Container);
        }
    }
}