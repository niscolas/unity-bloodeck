namespace Bloodeck
{
    public class EntityController : IEntity
    {
        public IEntityComponents Components => _humbleObject.Components;

        public string Name => _humbleObject.Name;

        private readonly IEntity _humbleObject;

        public EntityController(IEntity humbleObject)
        {
            _humbleObject = humbleObject;
        }
    }
}