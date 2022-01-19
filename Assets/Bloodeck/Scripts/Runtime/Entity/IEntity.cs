namespace Bloodeck
{
    public interface IEntity : IEntityData
    {
        void LoadTemplate(IEntityTemplate template);
    }
}