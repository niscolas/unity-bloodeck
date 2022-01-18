namespace Bloodeck
{
    public class DefaultEntityFromTemplateFactory : IEntityFromTemplateFactory
    {
        public IEntity Instantiate(IEntityTemplate template)
        {
            return new EntityController(
                new DefaultEntityData(default, template));
        }
    }
}