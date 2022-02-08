using Zenject;

namespace Bloodeck.View
{
    public class GlobalCardMonoInstaller : MonoInstaller<GlobalCardMonoInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<HeldCard>().AsSingle();
        }
    }
}