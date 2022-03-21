using Zenject;

namespace Bloodeck.Zenject
{
    public class EntityFiltersMonoInstaller : MonoInstaller<EntityFiltersMonoInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<OpponentsOnlyEntityFilter>().AsSingle();
        }
    }
}