namespace Bloodeck
{
    public class EntityProxy : IEntity
    {
        public IEntityComponents Components { get; }

        public string Name { get; }

        private readonly EntityController _controller;

        public EntityProxy(IEntityComponents components, string name = default)
        {
            _controller = new EntityController(this);

            Components = components;
            Name = name;
        }
    }
}