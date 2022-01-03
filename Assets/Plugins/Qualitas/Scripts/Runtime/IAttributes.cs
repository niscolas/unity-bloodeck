namespace Qualitas
{
    public interface IAttributes
    {
        bool Add(IAttributeType type, IAttribute attribute);

        bool TryGet(IAttributeType type, out IAttribute attribute);
    }
}