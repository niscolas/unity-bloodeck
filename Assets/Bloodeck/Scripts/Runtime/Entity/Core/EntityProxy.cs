namespace Bloodeck
{
    public class EntityProxy : IEntity
    {
        public IEntityComponents Components { get; }

        public string Name { get; }

        private static int _creationCounter = 0;

        private readonly EntityController _controller;

        public EntityProxy(IEntityComponents components, string name = default)
        {
            _controller = new EntityController(this);

            Components = components;
            if (name == default)
            {
                Name = $"{nameof(EntityProxy)}_{_creationCounter}";
            }
            else
            {
                Name = name;
            }

            _creationCounter++;
        }

        public static void ResetCreationCounter()
        {
            _creationCounter = 0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}