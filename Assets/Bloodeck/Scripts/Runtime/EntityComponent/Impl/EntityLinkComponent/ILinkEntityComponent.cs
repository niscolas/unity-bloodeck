namespace Bloodeck
{
    public interface ILinkEntityComponent<T> : IEntityComponent
    {
        T Link { get; }
    }
}