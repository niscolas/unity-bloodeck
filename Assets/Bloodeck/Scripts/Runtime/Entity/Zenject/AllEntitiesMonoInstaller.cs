using Zenject;

namespace Bloodeck
{
    public class AllEntitiesMonoInstaller : MonoInstaller<AllEntitiesMonoInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ParentCollection<IEntity, EntityMB>>()
                .WithId(ZenjectIds.AllEntitiesId)
                .AsSingle();
        }
    }
}