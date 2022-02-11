namespace Bloodeck
{
    public interface IEntityFilter
    {
        IEntities Filter(IEntities entities, IEntity instigator = null);
    }
}