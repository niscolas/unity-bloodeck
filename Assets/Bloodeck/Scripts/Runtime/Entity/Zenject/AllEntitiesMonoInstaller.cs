using Zenject;

namespace Bloodeck
{
    public class AllEntitiesMonoInstaller : MonoInstaller<AllEntitiesMonoInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IEntities>()
                .WithId(ZenjectIds.AllEntitiesId)
                .To<SerializableEntities>()
                .AsSingle();
        }
    }
}