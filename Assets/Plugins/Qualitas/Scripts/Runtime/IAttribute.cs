namespace Qualitas
{
    public interface IAttribute { }

    public interface IAttribute<T> : IAttribute
    {
        public T Value { get; }
    }
}