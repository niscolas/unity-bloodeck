namespace Bloodeck
{
    public interface IEntity
    {
        IEntityComponents Components { get; }

        string Name { get; }
    }
}