namespace Bloodeck
{
    public interface IComponent { }

    public interface IComponent<T> : IComponent
    {
        T Owner { get; }
    }
}