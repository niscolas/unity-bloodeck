namespace Bloodeck
{
    public interface IEntityFromTemplateFactory
    {
        IEntity Instantiate(IEntityTemplate template);
    }
}