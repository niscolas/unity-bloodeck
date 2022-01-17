namespace Bloodeck
{
    public interface IEntityData
    {
        IEntityComponents Components { get; }

        string Name { get; }

        IEntityTemplate Template { get; }
    }
}