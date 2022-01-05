using Zenject;

namespace Bloodeck
{
    public class CardMonoInstaller : MonoInstaller<CardMonoInstaller>
    {
        public override void InstallBindings()
        {
            CardInstaller.Install(Container);
        }
    }
}