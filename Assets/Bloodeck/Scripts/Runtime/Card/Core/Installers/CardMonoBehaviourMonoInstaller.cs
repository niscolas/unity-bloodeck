using Zenject;

namespace Bloodeck
{
    public class CardMonoBehaviourMonoInstaller : MonoInstaller<CardMonoBehaviourMonoInstaller>
    {
        public override void InstallBindings()
        {
            CardMonoBehaviourInstaller.Install(Container);
        }
    }
}