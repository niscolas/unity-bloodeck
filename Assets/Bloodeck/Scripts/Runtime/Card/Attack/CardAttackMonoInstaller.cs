using Zenject;

namespace Bloodeck
{
    public class CardAttackMonoInstaller : MonoInstaller<CardAttackMonoInstaller>
    {
        public override void InstallBindings()
        {
            CardAttackInstaller.Install(Container);
        }
    }
}